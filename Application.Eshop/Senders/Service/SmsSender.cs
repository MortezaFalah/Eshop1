using Application.Eshop.Senders.Interface;
using Domain.Eshop.Models.User;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Melipayamak;
using RedmentCore.Communication.Sms.MeliPayamak;
using Application.Eshop.Statics;


namespace Application.Eshop.Senders.Service
{
    public class SmsSender : ISmsSender
    {
        private readonly SendSoapClient melipayam;


  
        public SmsSender()
        {
            melipayam = new SendSoapClient(SendSoapClient.EndpointConfiguration.SendSoap);
        }
        public async Task<string> SendSmsAsync(string mobile, string message, bool isFlash = true)
        {
           
            return await melipayam.SendSimpleSMS2Async("09116307457",MeliPayamStatics.ApiKey , mobile,MeliPayamStatics.Sender, message, isFlash);
        }

 
    }
}
