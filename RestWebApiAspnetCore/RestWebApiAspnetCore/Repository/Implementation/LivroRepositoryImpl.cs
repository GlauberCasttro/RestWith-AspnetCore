using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestWebApiAspnetCore.Model;
using RestWebApiAspnetCore.Model.Context;

namespace RestWebApiAspnetCore.Repository.Implementation
{
    public class LivroRepositoryImpl : ILivroRepository
    {
        private MySqlContext _context;

        public LivroRepositoryImpl(MySqlContext context)
        {
            _context = context;

        }
        public Livro Create(Livro livro)
        {
            try
            {
                _context.Add(livro);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return livro;
        }

        public Livro FindById(long id)
        {

            return _context.Livro.SingleOrDefault(p => p.Id.Equals(id));
        }

        public List<Livro> FindAll()
        {
            return _context.Livro.ToList();
        }

        public Livro Update(Livro livro)
        {
            if (!Exist(livro.Id)) return null;
            var livroAlterado = _context.Livro.SingleOrDefault(l => l.Id.Equals(livro.Id));

            if (livroAlterado != null)
            {
                _context.Entry(livroAlterado).CurrentValues.SetValues(livro);
                _context.SaveChanges();
            }
            return livroAlterado;
        }

        public void Delete(long id)
        {
            var livroDeletado = _context.Livro.SingleOrDefault(l => l.Id.Equals(id));

            try
            {
                if (livroDeletado != null)
                {
                    _context.Livro.Remove(livroDeletado);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }

        public bool Exist(long? livroId)
        {
            return _context.Livro.Any(l => l.Id.Equals(livroId));
        }


    }
}
