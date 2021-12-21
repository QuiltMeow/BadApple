using System;
using System.Net;
using System.Threading;

namespace BadApple
{
    public class MediaServer
    {
        private readonly HttpListener listener;
        private readonly Func<HttpListenerRequest, byte[]> responseHandler;

        public MediaServer(string prefix, Func<HttpListenerRequest, byte[]> responseHandler)
        {
            listener = new HttpListener();
            listener.Prefixes.Add(prefix);
            this.responseHandler = responseHandler;
            listener.Start();
        }

        public void run()
        {
            ThreadPool.QueueUserWorkItem(voidCallback =>
            {
                try
                {
                    while (listener.IsListening)
                    {
                        ThreadPool.QueueUserWorkItem(callback =>
                        {
                            HttpListenerContext context = callback as HttpListenerContext;
                            try
                            {
                                byte[] buffer = responseHandler(context.Request);
                                context.Response.ContentLength64 = buffer.Length;
                                context.Response.ContentType = "application/octet-stream";
                                context.Response.OutputStream.Write(buffer, 0, buffer.Length);
                            }
                            catch (Exception ex)
                            {
                                Console.Error.WriteLine("處理請求時發生例外狀況 : " + ex.Message);
                            }
                            finally
                            {
                                context.Response.OutputStream.Close();
                            }
                        }, listener.GetContext());
                    }
                }
                catch
                {
                }
            });
        }

        public void stop()
        {
            listener.Stop();
            listener.Close();
        }
    }
}