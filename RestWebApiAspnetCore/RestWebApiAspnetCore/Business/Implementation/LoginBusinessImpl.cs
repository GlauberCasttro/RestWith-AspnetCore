using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using RestWebApiAspnetCore.Model;
using RestWebApiAspnetCore.Repository;
using RestWebApiAspnetCore.Security.Configuration;

namespace RestWebApiAspnetCore.Business.Implementation
{
   public class LoginBusinessImpl : ILoginBusiness
   {
       private  IUsuarioRepository _repository;
       private SigningConfiguration _signingConfiguration;
       private TokenConfiguration _tokenConfiguration;
        
        public LoginBusinessImpl (IUsuarioRepository repository, SigningConfiguration configuration, TokenConfiguration token)
        {
            _signingConfiguration = configuration;
            _tokenConfiguration = token;
            _repository = repository;
        }

        public object FindByLogin(Usuario user)
        {
            bool credentialsIsValid = true;
            if (user != null && !string.IsNullOrWhiteSpace(user.Login))
            {
                var baseUser = _repository.FindByLogin(user.Login);
                credentialsIsValid = (baseUser != null && user.Login == baseUser.Login && baseUser.Senha == user.Senha);
            }

            if (credentialsIsValid)

            {
                ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.Login,"Login"),
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString("N")),
                    new Claim(JwtRegisteredClaimNames.UniqueName,user.Login)
                
                });
                DateTime createDate = DateTime.Now;
                DateTime expiratinDate = createDate + TimeSpan.FromSeconds(_tokenConfiguration.Seconds);
                var handler = new JwtSecurityTokenHandler();
                string token = CreateToken(identity, createDate, expiratinDate, handler);

                return SucessObject(createDate,expiratinDate,token);
            }
            else
            {
                return ExceptionObject();
            }

        }

        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expiratinDate, JwtSecurityTokenHandler handler)
        {
            var securityToken = handler.CreateToken(new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Issuer = _tokenConfiguration.Issuer,
                Audience = _tokenConfiguration.Audience,
                SigningCredentials = _signingConfiguration.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expiratinDate
            });
            var token = handler.WriteToken(securityToken);
            return token;
        }

        private object ExceptionObject()
        {
            return new
            {
                autenticated = false,
                message = "FAILED"
            };

        }

        private object SucessObject(DateTime createDate, DateTime expiratinDate,string token)
        {
            return new
            {
                autenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expiratinDate.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            };
        }
   }
}
