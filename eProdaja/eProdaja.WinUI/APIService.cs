using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using eProdaja.Model;


namespace eProdaja.WinUI
{
    public class APIService
    {
        private string _route = null;
        //1. potrebno je dodati odredjni prop, koji ce nam pokazivati koji controller koristimo
        //2. hardcoded url(npr. promjena porta, i mor se rucno uvijek mijenjat za svalu metodu)
        //3. sinhroni poziv na api ne valja


        public APIService(string route)//Kontroler
        {
            _route = route;
        }
        public async Task<T> Get<T>(object request)
        {
            //url/Korisnici?Ime=request.Ime
            var url =  $"{Properties.Settings.Default.ApiURL}/{_route}";
            if (request != null)
            {
                url += "?";
                url += await request.ToQueryString();//jer je async ova metoda
            }
            var result = await url.GetJsonAsync<T>();
            return result;
        }
        public async Task<T> GetById<T>(object id)
        {
            var url = $"{Properties.Settings.Default.ApiURL}/{_route}/{id}";
            var result = await url.GetJsonAsync<T>();
            return result;
        }

        public async Task<T> Insert<T>(object request)
        {
            var url = $"{Properties.Settings.Default.ApiURL}/{_route}";
            var result = await url.PostJsonAsync(request).ReceiveJson<T>();//jer je update, reciveJson(vraca nazad..)
            return result;
        }

        public async Task<T> Update<T>(object id, object request)
        {
            var url = $"{Properties.Settings.Default.ApiURL}/{_route}/{id}";
            var result = await url.PutJsonAsync(request).ReceiveJson<T>();//jer je update, reciveJson(vraca nazad..)
            return result;
        }
    }
}
