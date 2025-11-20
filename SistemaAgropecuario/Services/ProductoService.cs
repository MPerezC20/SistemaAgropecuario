using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using SistemaAgropecuario.Models;
using System.Collections.Generic;
namespace SistemaAgropecuario.Services
{
    public class ProductoService
    {
        public List<Producto> ObtenerProductos()
        {
            var productos = new List<Producto>();
            using (var connection = Data.DatabaseConnection.GetConnection())
            {
                connection.Open();
                var query = "SELECT * FROM Productos WHERE estado = 'activo'";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            productos.Add(new Producto
                            {
                                IdProducto = (int)reader["id_producto"],
                                Nombre = reader["nombre"].ToString(),
                                Descripcion = reader["descripcion"].ToString(),
                                Categoria = reader["categoria"].ToString(),
                                PrecioUnitario = (decimal)reader["precio_unitario"],
                                UnidadMedida = reader["unidad_medida"].ToString(),
                                FechaCreacion = (DateTime)reader["fecha_creacion"],
                                Estado = reader["estado"].ToString()
                            });
                        }
                    }
                }
            }
            return productos;
        }

        public bool InsertarProducto(Producto producto)
        {
            using (var connection = Data.DatabaseConnection.GetConnection())
            {
                connection.Open();
                var query = @"INSERT INTO Productos (nombre, descripcion, categoria, precio_unitario, unidad_medida, fecha_creacion, estado) 
                             VALUES (@nombre, @descripcion, @categoria, @precio, @unidad, @fecha, @estado)";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@categoria", producto.Categoria);
                    command.Parameters.AddWithValue("@precio", producto.PrecioUnitario);
                    command.Parameters.AddWithValue("@unidad", producto.UnidadMedida);
                    command.Parameters.AddWithValue("@fecha", DateTime.Now);
                    command.Parameters.AddWithValue("@estado", "activo");

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool ActualizarProducto(Producto producto)
        {
            using (var connection = Data.DatabaseConnection.GetConnection())
            {
                connection.Open();
                var query = @"UPDATE Productos SET nombre=@nombre, descripcion=@descripcion, categoria=@categoria, 
                             precio_unitario=@precio, unidad_medida=@unidad WHERE id_producto=@id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", producto.IdProducto);
                    command.Parameters.AddWithValue("@nombre", producto.Nombre);
                    command.Parameters.AddWithValue("@descripcion", producto.Descripcion);
                    command.Parameters.AddWithValue("@categoria", producto.Categoria);
                    command.Parameters.AddWithValue("@precio", producto.PrecioUnitario);
                    command.Parameters.AddWithValue("@unidad", producto.UnidadMedida);

                    return command.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool EliminarProducto(int idProducto)
        {
            using (var connection = Data.DatabaseConnection.GetConnection())
            {
                connection.Open();
                var query = "UPDATE Productos SET estado='inactivo' WHERE id_producto=@id";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idProducto);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}