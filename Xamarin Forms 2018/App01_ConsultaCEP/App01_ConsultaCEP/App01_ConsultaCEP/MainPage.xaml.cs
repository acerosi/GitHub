using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultaCEP.Serviço;
using App01_ConsultaCEP.Serviço.Modelo;

namespace App01_ConsultaCEP
{
   // Learn more about making custom code visible in the Xamarin.Forms previewer
   // by visiting https://aka.ms/xamarinforms-previewer
   [DesignTimeVisible(false)]
   public partial class MainPage : ContentPage
   {
      public MainPage()
      {
         InitializeComponent();

         BOTAO.Clicked += BuscarCep;

       }
      private void BuscarCep(object sendert, EventArgs args)
      {
         string cep = CEP.Text.Trim();

         if (IsValidCEP(cep))
         {
            try
            {
               Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);

               if (end != null)
               {
                  RESULTADO.Text = string.Format("Endereço: {0} - {1} - {2} - {3}", end.logradouro, end.bairro, end.localidade, end.uf);
               }
               else
               {
                  DisplayAlert("ATENÇÃO", "Endereço não encontrado", "OK");
               }
               
            }
            catch(Exception e)
            {
               DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
            }
         }
      }

      private bool IsValidCEP(string cep)
      {
         bool valido = true;

         if (cep.Length != 8)
         {
            DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres", "OK");
            valido = false;
         }

         int NovoCEP = 0;
         if (!int.TryParse(cep, out NovoCEP))
         {
            DisplayAlert("ERRO", "CEP inválido! O CEP deve conter somente números", "OK");
            valido = false;
         }

         return valido;
      }
   }
}
