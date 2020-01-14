using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Model;

namespace RestWebApiAspnetCore.Services.Implementation
{
    public class PessoaServiceImpl : IPessoaService
    {
        private volatile int count;

        public Pessoa Create(Pessoa pessoa)
        {
            return pessoa;
        }

        public Pessoa FindById(long id)
        {
            return new Pessoa
            {
                Id = 1,
                Nome = "Glauber",
                Sobrenome = "Castro",
                Endereco = "Rua rio grande do sul, 646",
                Genero = "Masculino"
            };
        }

        public List<Pessoa> FindAll()
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            for (int i = 0; i<= 10; i++)
            {
                Pessoa pes = mockpessoa(i);

                pessoas.Add(pes);
            }

            return pessoas;
        }

      
        public Pessoa Update(Pessoa pessoa)
        {
            return pessoa;
        }

        public void Delete(long id)
        {

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
