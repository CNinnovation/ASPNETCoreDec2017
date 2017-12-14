using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    public class HttpHelper<T> : IDisposable
    {
        private HttpClient _client = new HttpClient();


        public async Task<IEnumerable<T>> GetAllAsync(string url)
        {
            HttpResponseMessage resp = await _client.GetAsync(url);
            resp.EnsureSuccessStatusCode();
            string json = await resp.Content.ReadAsStringAsync();
            IEnumerable<T> items = JsonConvert.DeserializeObject<IEnumerable<T>>(json);
            return items;
        }

        public async Task<T> GetByIdAsync(string url, int id)
        {
            HttpResponseMessage resp = await _client.GetAsync($"{url}/{id}");
            resp.EnsureSuccessStatusCode();
            string json = await resp.Content.ReadAsStringAsync();
            T item = JsonConvert.DeserializeObject<T>(json);
            return item;
        }

        public async Task<T> PostAsync(string url, T item)
        {
            string json = JsonConvert.SerializeObject(item);
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage resp = await _client.PostAsync(url, content);
            resp.EnsureSuccessStatusCode();
            string jsonresult = await resp.Content.ReadAsStringAsync();
            T itemresult = JsonConvert.DeserializeObject<T>(jsonresult);
            return itemresult;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _client.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

    
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
