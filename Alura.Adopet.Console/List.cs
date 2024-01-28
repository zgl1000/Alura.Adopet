﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Adopet.Console
{
    [DocComando(instrucao: "list", documentacao: "adopet list comando que exibe no terminal o conteúdo cadastrado na base de dados da Adopet.")]
    internal class List
    {
        HttpClient client;

        public List() 
        { 
            this.client= ConfiguraHttpClient("http://localhost:5057");
        }

        public async Task ListaDadosPetsDaAPIAsync()
        {
            var pets = await ListPetsAsync();
            foreach (var pet in pets)
            {
                System.Console.WriteLine(pet);
            }
        }

        async Task<IEnumerable<Pet>?> ListPetsAsync()
        {
            HttpResponseMessage response = await client.GetAsync("pet/list");
            return await response.Content.ReadFromJsonAsync<IEnumerable<Pet>>();
        }

        HttpClient ConfiguraHttpClient(string url)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            _client.BaseAddress = new Uri(url);
            return _client;
        }
    }
}
