using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.ComponentModel;

namespace Hilo
{
    public class Descargador
    {
        private string _html;
        private Uri _URLdeLaPagina;

        public delegate void EventProgress(int status);
        public event EventProgress evento_Progreso;
        public delegate void EventCompleted(string web);
        public event EventCompleted evento_Terminado;

        /// <summary>
        /// Recibe una URI.
        /// </summary>
        /// <param name="link"></param>
        public Descargador(Uri link)
        {
            this._html = "";
            this._URLdeLaPagina = link;
        }

        /// <summary>
        /// Inicia la descarga de la Pagina.
        /// </summary>
        public void IniciarDescarga()
        {
            try
            {
                WebClient cliente = new WebClient();

                cliente.DownloadProgressChanged += WebClientDownloadProgressChanged;
                cliente.DownloadStringCompleted += WebClientDownloadCompleted;

                cliente.DownloadStringAsync(this._URLdeLaPagina);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        /// <summary>
        /// Progreso de descarga de Webclient cambiado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.evento_Progreso(e.ProgressPercentage);
        }
        /// <summary>
        /// Progreso de descarga de WebClient Terminado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void WebClientDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                this._html = e.Result;
            }
            catch (Exception exception)
            {
                this._html = exception.Message;
            }
            finally
            {
                this.evento_Terminado(this._html);
            }
        }
    }
}
