//using ProyectoSelectos.GenericRepository;
using Proyectos.Ulatina.Model;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Ulatina.Topicos.GenericRepository;

namespace Proyecto.Ulatina.BL.Dominio.Repositorio
{
    internal class Articulo
    {
        
        private ProyectoFinalEntities _context = new ProyectoFinalEntities();
        //private DbContext elcontecto = new DbContext();
            


        public Articulo()
        {
        }

        internal IList<Proyectos.Ulatina.Model.Articulo> ListarTodos()
        {
            IList<Proyectos.Ulatina.Model.Articulo> resultado = _context.Articulo.ToList();
                return resultado;
        }

        

        //internal IList<Articulo> ConsultaPorNombreDeProducto(string elNombreDelProducto)
        //{
        //    // para usar el .ToList(), se requiere haber incluido el System.Linq;
        //    IList<Articulo> losArticulos = _context.Articuloes.Where(p => p.nombre.Contains(elNombreDelProducto));
        //    return losArticulos;
        //}

        internal Articulo ConsultaProductosPorNumero(int miNumeroDeArticulo)
        {
            Articulo elArticulo = _context.Articuloes.Include("Articulo").Where(p => p.idArticulo() == miNumeroDeArticulo).ToList();
            return elArticulo;
        }

        internal IList<Articulo> ListarProductos()
        {
            // para usar el .ToList(), se requiere haber incluido el System.Linq;
            var losArticulos = _context.Articuloes.GetAll<Articulo>(null, _includeTables, null, null).ToList();
            
            return losArticulos;
        }
    }
}
