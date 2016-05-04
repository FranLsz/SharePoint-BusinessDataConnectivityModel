using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Contexts;
using System.Security;
using Microsoft.BusinessData.Infrastructure.SecureStore;
using Microsoft.BusinessData.SystemSpecific;
using Microsoft.BusinessData.MetadataModel;
using Microsoft.BusinessData.Runtime;
using Microsoft.Office.SecureStoreService.Server;
using Microsoft.SharePoint;
using IContextProperty = Microsoft.BusinessData.SystemSpecific.IContextProperty;


namespace SpModelos.Alumnos
{
    /// <summary>
    /// All the methods for retrieving, updating and deleting data are implemented in this class file.
    /// The samples below show the finder and specific finder method for Alumno.
    /// </summary>
    public class AlumnoService : IContextProperty
    {
        public IMethodInstance MethodInstance { get; set; }
        public ILobSystemInstance LobSystemInstance { get; set; }
        public IExecutionContext ExecutionContext { get; set; }

        public static string Username = string.Empty;
        public static string Password = string.Empty;

        public static void GetCredenciales(out string user, out string pwd)
        {
            var appId = "Alumno";
            user = string.Empty;
            pwd = string.Empty;
            ISecureStoreProvider provider = SecureStoreProviderFactory.Create();
            ISecureStoreServiceContext providContext = provider as ISecureStoreServiceContext;
            providContext.Context = SPServiceContext.GetContext(new SPSite("http://pruebassp2"));


            using (var creds = provider.GetCredentials(appId))
            {
                if (creds != null)
                {
                    foreach (var c in creds)
                    {
                        if (c.CredentialType == SecureStoreCredentialType.UserName)
                        {
                            user = GetCredentialFromString(c.Credential);
                        }
                        else if (c.CredentialType == SecureStoreCredentialType.Password)
                        {
                            pwd = GetCredentialFromString(c.Credential);
                        }
                    }
                }
            }
        }

        private static string GetCredentialFromString(SecureString credential)
        {
            if (credential == null)
            {
                return null;
            }

            IntPtr texto = IntPtr.Zero;

            try
            {
                texto = Marshal.SecureStringToBSTR(credential);
                return Marshal.PtrToStringBSTR(texto);
            }
            finally
            {
                if (texto != IntPtr.Zero)
                {
                    Marshal.FreeBSTR(texto);
                }
            }
        }

        /// <summary>
        /// This is a sample specific finder method for Alumno.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Alumno</returns>
        public static Alumno ReadItem(int Id)
        {
            var user = string.Empty;
            var pwd = string.Empty;

            GetCredenciales(out user, out pwd);

            //TODO: This is just a sample. Replace this simple sample with valid code.
            Alumno alumno = new Alumno();
            return alumno;
        }
        /// <summary>
        /// This is a sample finder method for Alumno.
        /// If you want to delete or rename the method think about changing the xml in the BDC model file as well.
        /// </summary>
        /// <returns>IEnumerable of Entities</returns>
        public static IEnumerable<Alumno> ReadList()
        {
            //TODO: This is just a sample. Replace this simple sample with valid code.
            Alumno[] alumnoList = new Alumno[1];
            return alumnoList;
        }

        public static void DeleteItem()
        {
            throw new System.NotImplementedException();
        }


    }
}
