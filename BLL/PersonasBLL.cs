using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using RegistroTarea3.DAL;
using RegistroTarea3.Entidades;

namespace RegistroTarea3.BLL
{
    public class PersonasBLL
    {
        //Guardar *********************
        public static bool Guardar(Personas personas)
        {
            if (!Existe(personas.PersonaId))
                return Insertar(personas);
            else
                return Modificar(personas);
        }
        //Insertar *********************
        private static bool Insertar(Personas personas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Personas.Add(personas);
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        //Modificar *********************
        public static bool Modificar(Personas personas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(personas).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        //Eliminar *********************
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var personas = contexto.Personas.Find(id);
                if (personas != null)
                {
                    contexto.Personas.Remove(personas);
                    paso = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }
        //Buscar *********************
        public static Personas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Personas personas;
            try
            {
                personas = contexto.Personas.Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return personas;
        }
        //GetList *********************
        public static List<Personas> GetList(Expression<Func<Personas, bool>> criterio)
        {
            List<Personas> lista = new List<Personas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Personas.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
        //Existe *********************
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Personas.Any(d => d.PersonaId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }
        //Get *********************
        public static List<Personas> GetPersonas()
        {
            List<Personas> lista = new List<Personas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Personas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return lista;
        }
    }
}