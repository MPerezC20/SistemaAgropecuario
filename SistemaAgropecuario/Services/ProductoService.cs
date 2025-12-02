using System;
using System.Collections.Generic;
using SistemaAgropecuario.Models;
using SistemaAgropecuario.Data;
using MySqlConnector;

namespace SistemaAgropecuario.Services
{
    public class ProductoService
    {
        public List<Producto> ObtenerProductos()
        {
            var productos = new List<Producto>();

            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                var query = @"SELECT id_producto, nombre, descripcion, categoria,
                                     precio_unitario, unidad_medida, fecha_creacion, estado
                              FROM productos
                              WHERE estado = 'activo'";

                using (var command = new MySqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    int iId = reader.GetOrdinal("id_producto");
                    int iNombre = reader.GetOrdinal("nombre");
                    int iDescripcion = reader.GetOrdinal("descripcion");
                    int iCategoria = reader.GetOrdinal("categoria");
                    int iPrecio = reader.GetOrdinal("precio_unitario");
                    int iUnidad = reader.GetOrdinal("unidad_medida");
                    int iFecha = reader.GetOrdinal("fecha_creacion");
                    int iEstado = reader.GetOrdinal("estado");

                    while (reader.Read())
                    {
                        var p = new Producto
                        {
                            IdProducto = reader.GetInt32(iId),
                            Nombre = reader.IsDBNull(iNombre) ? string.Empty : reader.GetString(iNombre),
                            Descripcion = reader.IsDBNull(iDescripcion) ? string.Empty : reader.GetString(iDescripcion),
                            Categoria = reader.IsDBNull(iCategoria) ? string.Empty : reader.GetString(iCategoria),
                            PrecioUnitario = reader.GetDecimal(iPrecio),
                            UnidadMedida = reader.IsDBNull(iUnidad) ? string.Empty : reader.GetString(iUnidad),
                            FechaCreacion = reader.GetDateTime(iFecha),
                            Estado = reader.IsDBNull(iEstado) ? string.Empty : reader.GetString(iEstado)
                        };

                        productos.Add(p);
                    }
                }
            }

            return productos;
        }

        public bool InsertarProducto(Producto producto)
        {
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                var query = @"INSERT INTO productos
                                (nombre, descripcion, categoria, precio_unitario,
                                 unidad_medida, fecha_creacion, estado)
                              VALUES
                                (@nombre, @descripcion, @categoria, @precio,
                                 @unidad, @fecha, @estado)";

                using (var command = new MySqlCommand(query, connection))
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
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                var query = @"UPDATE productos SET
                                nombre = @nombre,
                                descripcion = @descripcion,
                                categoria = @categoria,
                                precio_unitario = @precio,
                                unidad_medida = @unidad
                              WHERE id_producto = @id";

                using (var command = new MySqlCommand(query, connection))
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
            using (var connection = DatabaseConnection.GetConnection())
            {
                connection.Open();

                var query = "UPDATE productos SET estado = 'inactivo' WHERE id_producto = @id";

                using (var command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@id", idProducto);
                    return command.ExecuteNonQuery() > 0;
                }
            }
        }
    }
}

