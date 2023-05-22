using ConsultarCEP.Services;
using ConsultarCEP.Services.Entitys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        private void ExecultarBuscaCep(Object sender, EventArgs args)
        {
            CEP_DIGITADO.Unfocus();
            if (CepIsValid(CEP_DIGITADO.Text.Trim()))
            {
                try
                {
                    Endereco end = ViaCepService.BuscarEnderecoPorCep(CEP_DIGITADO.Text.Trim());

                    if (end != null)
                    {
                        CEP_DIGITADO.Text = "";

                        LOGRADOURO.Text = String.IsNullOrEmpty(end.logradouro) ? "LOGRADOURO: Não Encontrado" : $"LOGRADOURO: {end.logradouro}";
                        BAIRRO.Text = String.IsNullOrEmpty(end.bairro) ? "BAIRRO: Não Encontrado" : $"BAIRRO: {end.bairro}";
                        LOCALIDADE.Text = $"LOCALIDADE: {end.localidade}";
                        UF.Text = $"UF: {end.uf}";
                        CEP.Text = $"CEP: {end.cep}";
                    }
                    else
                    {
                        LimparCamposEndereco();
                        DisplayAlert("Erro", "O endereço não foi encontrado para o CEP informado !", "OK");
                    }
                }
                catch (Exception ex)
                {
                    LimparCamposEndereco();
                    DisplayAlert("Erro", "Infelizmente ocorreu um erro, tente novamente mais tarde.", "Ok");
                }
            }
        }

        private bool CepIsValid(string cep)
        {
            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "Verifique o Cep digitado, ele precisa ter 8 caracteres !!", "Ok");
                return false;
            }
            int resultadoCep;
            if(!int.TryParse(cep,out resultadoCep))
            {
                DisplayAlert("Erro", "Verifique o Cep digitado, ele deve conter apenas Números !!", "Ok");
                return false;
            }

            return true;
        }

        private void LimparCamposEndereco()
        {
            LOGRADOURO.Text = "";
            BAIRRO.Text = "";
            LOCALIDADE.Text = "";
            UF.Text = "";
            CEP.Text = "";
        }
    }
}
