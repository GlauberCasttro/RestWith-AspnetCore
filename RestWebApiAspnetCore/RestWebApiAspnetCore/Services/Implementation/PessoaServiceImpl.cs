﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Model;

namespace RestWebApiAspnetCore.Services.Implementation
{
    public class PessoaServiceImpl : IPessoaService
    {

        private MySqlContext _context;

        public PessoaServiceImpl( MySqlContext context)
        {
            _context = context;
        }
        private volatile int count;

        public Pessoa Create(Pessoa pessoa)
        {
            try
            {
                _context.Add(pessoa);
                _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return pessoa;
        }

        public Pessoa FindById(long id)
        {

           return _context.Pessoa.SingleOrDefault(p => p.Id.Equals(id));

            //return new Pessoa
            //{
            //    Id = 1,
            //    Nome = "Glauber",
            //    Sobrenome = "Castro",
            //    Endereco = "Rua rio grande do sul, 646",
            //    Genero = "Masculino"
            //};
        }

        public List<Pessoa> FindAll()
        {

          return  _context.Pessoa.ToList();
            //List<Pessoa> pessoas = new List<Pessoa>();

            //for (int i = 0; i<= 10; i++)
            //{
            //    Pessoa pes = mockpessoa(i);

            //    pessoas.Add(pes);
            //}
        }

      
        public Pessoa Update(Pessoa pessoa)
        {

            if (!Exist(pessoa.Id)) return new Pessoa();
            var result = _context.Pessoa.SingleOrDefault(p => p.Id.Equals(pessoa.Id));

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(pessoa);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        
            return result;
        }

        private bool Exist(long? pessoaId)
        {
            return _context.Pessoa.Any(p => p.Id.Equals(pessoaId));
        }

        public void Delete(long id)
        {

            var result = _context.Pessoa.SingleOrDefault(p => p.Id.Equals(id));
            try
            {
                if (result != null)
                {
                    _context.Pessoa.Remove(result);
                    _context.SaveChanges();
                }
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Pessoa mockpessoa(int i)
        {
            return new Pessoa
            {
                Id = incrementGetID(),
                Nome = "Pessoa Nome" + i,
                Sobrenome = "Pessoa sobrenome" + i,
                Endereco = "Rua rio grande do sul, 646" + i,
                Genero = "Masculino" + i
            };
        }

        private long incrementGetID()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
