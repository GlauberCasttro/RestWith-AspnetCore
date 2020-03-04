using RestWebApiAspnetCore.Model;
using RestWebApiAspnetCore.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using RestWebApiAspnetCore.Repository.Generic;

namespace RestWebApiAspnetCore.Repository.Implementation
{
    public class PessoaRepositoryImpl : GenericRepository<Pessoa>, IPessoaRepository
    {

        public PessoaRepositoryImpl(MySqlContext context) : base(context) { }

        public List<Pessoa> FindByName(string firstName, string lastName)
        {
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Pessoa.Where(p => p.Nome.Contains(firstName) && (p.Sobrenome.Contains(lastName))).ToList();
            }
            else if (string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                return _context.Pessoa.Where(p => p.Sobrenome.Contains(lastName)).ToList();
            }
            else if (!string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return _context.Pessoa.Where(p => p.Nome.Contains(firstName)).ToList();
            }
            else
            {
                return _context.Pessoa.ToList();
            }

        }

    }
}
