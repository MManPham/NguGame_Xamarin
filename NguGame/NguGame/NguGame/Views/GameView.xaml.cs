using NguGame.Models;
using NguGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NguGame.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GameView : ContentPage
	{
        public GameViewVM ViewModel { get; set; }

        public GameView(GameViewVM gameVM)
		{

			InitializeComponent ();

            ViewModel = gameVM;
            BindingContext  = gameVM;

        }

        private async  void AnswerA_Clicked(object sender, EventArgs e)
        {
            
            if (answerA.Text != ViewModel.currQuestion.rightAnswer)
            {
                if (ViewModel.LuotNgu > 1)
                {
                    bool checkCont = await DisplayAlert("Ngudấdf", "Bạn đã chọn câu trả lời thật ngu người :) Tiếp tục để ngu tiếp nào", "Tiếp nào", "Nghỉ dẹp");
                    if (checkCont)
                        MessagingCenter.Send(this, "WrongAnswer", answerA.Text);
                    else await Navigation.PopToRootAsync();
                }
                else MessagingCenter.Send(this, "WrongAnswer", answerA.Text);


            }
            else
            {
                MessagingCenter.Send(this, "RightAnswer", answerA.Text);
            }
            BindingContext = "";
            BindingContext = ViewModel;

        }

        private async void AnswerB_Clicked(object sender, EventArgs e)
        {
            if (answerB.Text != ViewModel.currQuestion.rightAnswer)
            {
                if (ViewModel.LuotNgu > 1)
                {
                    bool checkCont = await DisplayAlert("Ngudấdf", "Bạn đã chọn câu trả lời thật ngu người :) Tiếp tục để ngu tiếp nào", "Tiếp nào", "Nghỉ dẹp");
                    if (checkCont)
                        MessagingCenter.Send(this, "WrongAnswer", answerA.Text);
                    else await Navigation.PopToRootAsync();
                }
                else MessagingCenter.Send(this, "WrongAnswer", answerA.Text);
            }
            else
            {
                MessagingCenter.Send(this, "RightAnswer", answerA.Text);
            }
            BindingContext = "";
            BindingContext = ViewModel;
        }

        private async void AnswerC_Clicked(object sender, EventArgs e)
        {
            if (answerC.Text != ViewModel.currQuestion.rightAnswer)
            {
                if (ViewModel.LuotNgu > 1)
                {
                    bool checkCont = await DisplayAlert("Ngudấdf", "Bạn đã chọn câu trả lời thật ngu người :) Tiếp tục để ngu tiếp nào", "Tiếp nào", "Nghỉ dẹp");
                    if (checkCont)
                        MessagingCenter.Send(this, "WrongAnswer", answerA.Text);
                    else await Navigation.PopToRootAsync();
                }
                else MessagingCenter.Send(this, "WrongAnswer", answerA.Text);


            }
            else
            {
                MessagingCenter.Send(this, "RightAnswer", answerA.Text);
            }
            BindingContext = "";
            BindingContext = ViewModel;
        }

        private async void AnswerD_Clicked(object sender, EventArgs e)
        {
            if (answerD.Text != ViewModel.currQuestion.rightAnswer)
            {
                if (ViewModel.LuotNgu > 1)
                {
                    bool checkCont =  await DisplayAlert("Ngudấdf", "Bạn đã chọn câu trả lời thật ngu người :) Tiếp tục để ngu tiếp nào", "Tiếp nào", "Nghỉ dẹp");
                    if (checkCont)
                        MessagingCenter.Send(this, "WrongAnswer", answerA.Text);
                    else await Navigation.PopToRootAsync();
                }
                else MessagingCenter.Send(this, "WrongAnswer", answerA.Text);

            }
            else
            {
                MessagingCenter.Send(this, "RightAnswer", answerA.Text);
            }
            BindingContext = "";
            BindingContext = ViewModel;
        }
    }
}