﻿using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ApmToTap
{
    public partial class ApmToTapPage : ContentPage
    {
        public ApmToTapPage()
        {
            InitializeComponent();
        }

        async void OnLoadButtonClicked(object sender, EventArgs args)
        {
            try
            {
                Stream stream = await GetStreamAsync("http://docs.xamarin.com/demo/IMG_1996.JPG"); 
                image.Source = ImageSource.FromStream(() => stream);
            }
            catch (Exception exc)
            {
                errorLabel.Text = exc.Message;
            }
        }
        
        async Task<Stream> GetStreamAsync(string uri)
        {
            TaskFactory factory = new TaskFactory();
            WebRequest request = WebRequest.Create(uri);
            WebResponse response = await factory.FromAsync<WebResponse>(request.BeginGetResponse,
                                                                        request.EndGetResponse,
                                                                        null);
            return response.GetResponseStream();
        }
    }
}

