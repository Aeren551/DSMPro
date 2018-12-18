
/*PROTECTED REGION ID(CreateDB_imports) ENABLED START*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DSMGenNHibernate.EN.DSM;
using DSMGenNHibernate.CEN.DSM;
using DSMGenNHibernate.CAD.DSM;

/*PROTECTED REGION END*/
namespace InitializeDB
{
public class CreateDB
{
public static void Create (string databaseArg, string userArg, string passArg)
{
        String database = databaseArg;
        String user = userArg;
        String pass = passArg;

        // Conex DB 
        SqlConnection cnn = new SqlConnection (@"Server=(local)\sqlexpress; database=master; integrated security=yes");

        // Order T-SQL create user
        String createUser = @"IF NOT EXISTS(SELECT name FROM master.dbo.syslogins WHERE name = '" + user + @"')
            BEGIN
                CREATE LOGIN ["                                                                                                                                     + user + @"] WITH PASSWORD=N'" + pass + @"', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
            END"                                                                                                                                                                                                                                                                                    ;

        //Order delete user if exist
        String deleteDataBase = @"if exists(select * from sys.databases where name = '" + database + "') DROP DATABASE [" + database + "]";
        //Order create databas
        string createBD = "CREATE DATABASE " + database;
        //Order associate user with database
        String associatedUser = @"USE [" + database + "];CREATE USER [" + user + "] FOR LOGIN [" + user + "];USE [" + database + "];EXEC sp_addrolemember N'db_owner', N'" + user + "'";
        SqlCommand cmd = null;

        try
        {
                // Open conex
                cnn.Open ();

                //Create user in SQLSERVER
                cmd = new SqlCommand (createUser, cnn);
                cmd.ExecuteNonQuery ();

                //DELETE database if exist
                cmd = new SqlCommand (deleteDataBase, cnn);
                cmd.ExecuteNonQuery ();

                //CREATE DB
                cmd = new SqlCommand (createBD, cnn);
                cmd.ExecuteNonQuery ();

                //Associate user with db
                cmd = new SqlCommand (associatedUser, cnn);
                cmd.ExecuteNonQuery ();

                System.Console.WriteLine ("DataBase create sucessfully..");
        }
        catch (Exception ex)
        {
                throw ex;
        }
        finally
        {
                if (cnn.State == ConnectionState.Open) {
                        cnn.Close ();
                }
        }
}

public static void InitializeData ()
{
            /*PROTECTED REGION ID(initializeDataMethod) ENABLED START*/

            try
            {
                //CAD
                //USUARIOS
                IUsuarioCAD _IusuarioCAD = new UsuarioCAD();
                IAdministradorCAD _IadministradorCAD = new AdministradorCAD();
                IAsistenteCAD _IasistenteCAD = new AsistenteCAD();
                IGrupoCAD _IgrupoCAD = new GrupoCAD();
                //EVENTO
                IEventoCAD _IeventoCAD = new EventoCAD();
                IEventoPagoCAD _IeventoPagoCAD = new EventoPagoCAD();
                IEventoGratisCAD _IeventoGratisCAD = new EventoGratisCAD();
                IEntradaCAD _IentradaCAD = new EntradaCAD();
                //OTROS
                IComentarioCAD _IcomentarioCAD = new ComentarioCAD();
                IPremioCAD _IpremioCAD = new PremioCAD();
                IMensajeCAD _ImensajeCAD = new MensajeCAD();


                //EN

                UsuarioEN usuarioEN = new UsuarioEN();
                AdministradorEN administradorEN = new AdministradorEN();
                AsistenteEN asistenteEN = new AsistenteEN();
                GrupoEN grupoEN = new GrupoEN();

                EventoEN eventoEN = new EventoEN();
                EventoPagoEN eventoPagoEN = new EventoPagoEN();
                EventoGratisEN eventoGratisEN = new EventoGratisEN();
                EntradaEN entradaEN = new EntradaEN();

                ComentarioEN comentarioEN = new ComentarioEN();
                PremioEN premioEN = new PremioEN();
                MensajeEN mensajeEN = new MensajeEN();

                //CEN

                UsuarioCEN usuarioCEN = new UsuarioCEN(_IusuarioCAD);
                AdministradorCEN administradorCEN = new AdministradorCEN(_IadministradorCAD);
                AsistenteCEN asistenteCEN = new AsistenteCEN(_IasistenteCAD);
                GrupoCEN grupoCEN = new GrupoCEN(_IgrupoCAD);

                EventoCEN enventoCEN = new EventoCEN(_IeventoCAD);
                EventoPagoCEN eventoPagoCEN = new EventoPagoCEN(_IeventoPagoCAD);
                EventoGratisCEN eventoGratisCEN = new EventoGratisCEN(_IeventoGratisCAD);
                EntradaCEN entradaCEN = new EntradaCEN(_IentradaCAD);

                ComentarioCEN comentarioCEN = new ComentarioCEN(_IcomentarioCAD);
                PremioCEN premioCEN = new PremioCEN(_IpremioCAD);
                MensajeCEN mensajeCEN = new MensajeCEN(_ImensajeCAD);

                //CP

                //ComentarioCP comentarioCP = new ComentarioCP();
                /* Adri aqui  se supone que hay que hacer comentarios
                 * *se supone que tienes que poner :
                 * ComentarioCP comentarioCP = new ComentarioCP();
                 *
                 * pero me da error asi que no se que hacer aqui */

                //USUARIO


                UsuarioEN usuario1EN = new UsuarioEN();

                usuario1EN.Nombre = " Adelaida_granada";
                usuario1EN.Correo = "granadita@gmail.com";
                usuario1EN.Contrasenya = "contra123";
                usuario1EN.Direccion = "C/ el gran mazapan saltarin 1, alicante , alicante, 03160";
                usuario1EN.Foto = "imagen.jpg";
                usuario1EN.Telefono = 679987543;

                usuarioCEN.CrearUsuario(usuario1EN.Correo, usuario1EN.Nombre, usuario1EN.Contrasenya, usuario1EN.Foto, usuario1EN.Direccion, usuario1EN.Telefono);


                UsuarioEN usuario2EN = new UsuarioEN();

                usuario2EN.Nombre = " Eustaquio_abichuela";
                usuario2EN.Correo = "abichuelita@gmail.com";
                usuario2EN.Contrasenya = "contra456";
                usuario2EN.Direccion = "C/ el gran mazapan saltarin 2, alicante , alicante, 03160";
                usuario2EN.Foto = "imagen1.jpg";
                usuario2EN.Telefono = 633456098;

                usuarioCEN.CrearUsuario(usuario2EN.Correo, usuario2EN.Nombre, usuario2EN.Contrasenya, usuario2EN.Foto, usuario2EN.Direccion, usuario1EN.Telefono);



                UsuarioEN usuario3EN = new UsuarioEN();

                usuario3EN.Nombre = "Ramiro_alcachofa";
                usuario3EN.Correo = "alcachofita@gmail.com";
                usuario3EN.Contrasenya = "contra789";
                usuario3EN.Direccion = "C/ el gran mazapan saltarin 3, alicante , alicante, 03160";
                usuario3EN.Foto = "imagen1.jpg";
                usuario3EN.Telefono = 633456098;

                usuarioCEN.CrearUsuario(usuario3EN.Correo, usuario3EN.Nombre, usuario3EN.Contrasenya, usuario3EN.Foto, usuario3EN.Direccion, usuario1EN.Telefono);


                AdministradorEN admin1EN = new AdministradorEN();

                admin1EN.Correo = "soyeladminsupremo@gmail.com";
                admin1EN.Nombre = "Tu todopoderoso Admin 69 ";
                admin1EN.Foto = "jisus.jpg";
                admin1EN.Contrasenya = "adminresucitalapatriatenecesita";
                admin1EN.Direccion = " C/ El olimpo de los supremos dioses,Sector A, Olimpo, 0000";
                admin1EN.Telefono = 666000999;

                //esto se ha cambiado de crear Administrador a crear usuario por lo que comento el profe de la sobrecargade metodos al heredar
                administradorCEN.CrearUsuario(admin1EN.Correo, admin1EN.Nombre, admin1EN.Contrasenya, admin1EN.Foto, admin1EN.Direccion, admin1EN.Telefono);


                

                List<String> LusuariosG = new List<string>();
                LusuariosG.Add(usuario1EN.Correo);
                LusuariosG.Add(usuario2EN.Correo);
                LusuariosG.Add(usuario3EN.Correo);
            
                 
                 
                  GrupoEN grupo1EN = new GrupoEN();
                  grupo1EN.Nombre = "Grupo el gran ";
                  grupoCEN.CrearGrupo(grupo1EN.Nombre, LusuariosG, 14);

                MensajeEN mensaje1EN = new MensajeEN ();

                mensaje1EN.Leido = false;
                mensaje1EN.Mensaje = "Hola, este es el primer mensaje que se ha enviado en la historia de nuestra web.";

                mensajeCEN.CrearMensaje (mensaje1EN.Mensaje, mensaje1EN.Leido, usuario1EN.Correo, usuario2EN.Correo);

                ComentarioEN comentario1EN = new ComentarioEN ();

                comentario1EN.Titulo = "El evento maravilloso";
                comentario1EN.Texto = "Tras asistir a este evento  me he quedado maravillada con este concurso tan divertido, ademas he ganado el 1er puesto y el premio ha sido genial.";
                comentario1EN.Likes = 666;

                
                //ComentarioCEN.crearComentario(comentario1EN.Titulo, comentario1EN.Texto, comentarioEN.Likes, usuario1EN.Correo);
                 


                /*  EventoEN evento1EN = new EventoEN();
                 *
                 * evento1EN.Nombre = "Concurso de comilones";
                 * evento1EN.Lugar = "C/ la marsopa acuatica feliz";
                 * evento1EN.Fecha = 2018 - 012 - 09;
                 * evento1EN.Genero = 1;
                 * evento1EN.Descripcion = "Veamos quien es capaz de comer mas yogures ! ";
                 * evento1EN.Tipo = DSMGenNHibernate.Enumerated.DSM.TipoEventoEnum{ 1};
                 *
                 * EventoCEN.crearEvento();
                 *
                 * PremioEN premio1EN = new PremioEN();
                 *
                 * premio1EN.Descripcion = "1000 � para comprar yogures";
                 * premio1EN.Nombre = "mas y mas Yogures";
                 *
                 * premioCEN.CrearPremio(premio1EN.Descripcion, evento1En.id, premio1EN.Nombre, "12", "6");*/













                /*PROTECTED REGION END*/
        }
        catch (Exception ex)
        {
                System.Console.WriteLine (ex.InnerException);
                throw ex;
        }
}
}
}
