using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Paxton4
{
	public partial class MainPage : ContentPage
	{
        public double stepValue { get; private set; }
        public Slider sliderMain { get; private set; }

        public Label sliderLabel { get; private set; }
        public Label perUnitCostLabel { get; private set; }
        public Label totalCostLabel { get; private set; }
        public Switch memorySwitch { get; private set; }
        public Switch officeSwitch { get; private set; }
        public Switch appleTvSwitch { get; private set; }
        public Entry nameEntry = new Entry();
        public Entry emailEntry = new Entry();

        public Entry phoneEntry = new Entry();

        public Picker computerPicker { get; private set; }

        int perUnitCost = 1000;
        int baseUnitCost = 1000;
        int upgradeCost = 0;
        double newStep = 0.0f;

        public MainPage()
        {
            InitializeComponent();

            StackLayout stackLayout = new StackLayout();
            this.Content = stackLayout;

            Frame imageFrame = setTopImage();
            stackLayout.Children.Add(imageFrame);

            setLabel("Customer Information", stackLayout);

            setInfoEntries(stackLayout);

            setLabel("Select Computer", stackLayout);

            setComputerPicker(stackLayout);

            setLabel("Select Upgrades", stackLayout);

            setMemoryRadio(stackLayout);
            setOfficeRadio(stackLayout);
            setAppleTvRadio(stackLayout);

            setLabel("Select Quantity", stackLayout);

            setQuantitySlider(stackLayout);

            setLabel("Cost: 15% discount on 4 or more!", stackLayout);

            setPerUnitCostLabels(stackLayout);

            setTotalCostLabels(stackLayout);

            setButtons(stackLayout);

            Content = new ScrollView
            {
                Content = stackLayout
            };

        }

       
        private Frame setTopImage()
        {
            Frame imageFrame = new Frame();
            imageFrame.OutlineColor = Color.Black;
            imageFrame.HeightRequest = 90;
            imageFrame.WidthRequest = 90;

            Image topImage = new Image();
            topImage.Source = "apple.png";
            topImage.HeightRequest = 90;
            topImage.WidthRequest = 90;
            topImage.VerticalOptions = LayoutOptions.Start;
            topImage.HorizontalOptions = LayoutOptions.Center;

            imageFrame.Content = topImage;

            return imageFrame;
        }

        private void setLabel(String label, StackLayout stackLayout)
        {
            Label nameLabel = new Label();
            nameLabel.Text = label;
            nameLabel.FontSize = 16;
            nameLabel.FontAttributes = FontAttributes.Bold;
            nameLabel.Margin = new Thickness(5, 15, 0, 5);
            stackLayout.Children.Add(nameLabel);
        }

        private void setInfoEntries(StackLayout stackLayout)
        {
            String[] labelName = new String[] { "Name", "Email", "Phone" };
            Entry[] entries = new Entry[] { nameEntry, emailEntry, phoneEntry };

            for (int i = 0; i < labelName.Length; i++)
            {
                StackLayout innerLayout = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal
                };
                var label = new Label
                {
                    Text = labelName[i],
                    FontSize = 10,
                    Margin = new Thickness(5, 10, 0, 0)

                };
                entries[i] = new Entry
                {
                    WidthRequest = 200,
                    FontSize = 10
                };
                innerLayout.Children.Add(label);
                innerLayout.Children.Add(entries[i]);
                stackLayout.Children.Add(innerLayout);
            }

            
        }

        private void setComputerPicker(StackLayout stackLayout)
        {
            computerPicker = new Picker
            {
                Title = "Computer",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(5, 0, 5, 0)
                
            };
            computerPicker.Items.Add("MacBook ($1000)");
            computerPicker.Items.Add("MacBook Air ($1500)");
            computerPicker.SelectedIndex = 0;
            computerPicker.SelectedIndexChanged += OnComputerSelection;

            stackLayout.Children.Add(computerPicker);
        }

        private void setMemoryRadio(StackLayout stackLayout)
        {
            StackLayout innerLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            var label = new Label
            {
                Text = "Memory ($100)   ",
                FontSize = 10,
                Margin = new Thickness(5, 10, 0, 0)

            };
            memorySwitch = new Switch
            {
                WidthRequest = 50,


            };
            memorySwitch.Toggled += (sender, args) =>
            {
                if (memorySwitch.IsToggled)
                {
                    upgradeCost += 100;
                    updatePerUnitCost();
                    updateTotalCost();
                }
                else
                {
                    upgradeCost -= 100;
                    updatePerUnitCost();
                    updateTotalCost();
                }
            };
            innerLayout.Children.Add(label);
            innerLayout.Children.Add(memorySwitch);
            stackLayout.Children.Add(innerLayout);
        }
        private void setOfficeRadio(StackLayout stackLayout)
        {
            StackLayout innerLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            var label = new Label
            {
                Text = "Office ($130)      ",
                FontSize = 10,
                Margin = new Thickness(5, 10, 0, 0)

            };
            officeSwitch = new Switch
            {
                WidthRequest = 50,


            };
            officeSwitch.Toggled += (sender, args) =>
            {
                if (officeSwitch.IsToggled)
                {
                    upgradeCost += 130;
                    updatePerUnitCost();
                    updateTotalCost();
                }
                else
                {
                    upgradeCost -= 130;
                    updatePerUnitCost();
                    updateTotalCost();
                }
                
            };
            innerLayout.Children.Add(label);
            innerLayout.Children.Add(officeSwitch);
            stackLayout.Children.Add(innerLayout);
        }
        private void setAppleTvRadio(StackLayout stackLayout)
        {
            StackLayout innerLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            var label = new Label
            {
                Text = "Apple TV  ($230)",
                FontSize = 10,
                Margin = new Thickness(5, 10, 0, 0)

            };
            appleTvSwitch = new Switch
            {
                WidthRequest = 50,


            };
            appleTvSwitch.Toggled += (sender, args) =>
            {
                if (appleTvSwitch.IsToggled)
                {
                    upgradeCost += 230;
                    updatePerUnitCost();
                    updateTotalCost();
                }
                else
                {
                    upgradeCost -= 230;
                    updatePerUnitCost();
                    updateTotalCost();
                }
            };

            innerLayout.Children.Add(label);
            innerLayout.Children.Add(appleTvSwitch);
            stackLayout.Children.Add(innerLayout);
        }
       
        private void setQuantitySlider(StackLayout stackLayout)
        {
            stepValue = 1.0;
            StackLayout innerLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            sliderMain = new Slider
            {
                Minimum = 0.0f,
                Maximum = 5.0f,
                Value = 0.0f,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            sliderMain.ValueChanged += OnSliderValueChanged;
            sliderLabel = new Label
            {
                Text = sliderMain.Value.ToString(),
                Margin = new Thickness(5,0,0,0)
                
            };

            innerLayout.Children.Add(sliderLabel);
            innerLayout.Children.Add(sliderMain);
            stackLayout.Children.Add(innerLayout);
        }

       
        private void setPerUnitCostLabels(StackLayout stackLayout)
        {
            StackLayout innerLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            var label = new Label
            {
                Text = "Per Unit Cost: ",
                FontSize = 12,

            };
            perUnitCostLabel = new Label
            {
                WidthRequest = 50,
                Text = "$" + baseUnitCost,
                FontSize = 12,
            };
            innerLayout.Children.Add(label);
            innerLayout.Children.Add(perUnitCostLabel);
            stackLayout.Children.Add(innerLayout);
        }

        private void setTotalCostLabels(StackLayout stackLayout)
        {
            StackLayout innerLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            var label = new Label
            {
                Text = "Total Cost:      ",
                FontSize = 12,


            };
            totalCostLabel = new Label
            {
                WidthRequest = 50,
                Text = "$" + baseUnitCost,
                FontSize = 12,

            };
            innerLayout.Children.Add(label);
            innerLayout.Children.Add(totalCostLabel);
            stackLayout.Children.Add(innerLayout);
        }
        private void setButtons(StackLayout stackLayout)
        {
            StackLayout innerLayout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };
            Button buyButton = new Button
            {
                Text = "Buy",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(10, 10, 0, 0)
            };
            Button closeButton = new Button
            {
                Text = "Clear",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(0, 10, 10, 0)
            };
            buyButton.Clicked += OnBuyButtonClick;
            closeButton.Clicked += OnClearButtonClick;
            innerLayout.Children.Add(buyButton);
            innerLayout.Children.Add(closeButton);
            stackLayout.Children.Add(innerLayout);
        }
        void OnSliderValueChanged(object sender, ValueChangedEventArgs e)
        {
            newStep = Math.Round(e.NewValue / stepValue);

            sliderMain.Value = newStep * stepValue;
            sliderLabel.Text = sliderMain.Value.ToString();
            updateTotalCost();
        }
        void OnComputerSelection(object sender, EventArgs args)
        {
            if (computerPicker.SelectedIndex == 0)
            {
                baseUnitCost = 1000;
                updatePerUnitCost();
                updateTotalCost();
            }
            else
            {
                baseUnitCost = 1500;
                updatePerUnitCost();
                updateTotalCost();
            }
        }

        void OnBuyButtonClick(object sender, EventArgs args)
        {
            OnAlertYesNoClicked(sender, args);   
        }

        void OnClearButtonClick(object sender, EventArgs args)
        {
            clearScreen();
        }

        void updateTotalCost()
        {
            double quantity = newStep * stepValue;
            double totalCost = perUnitCost * quantity;
            
            if(quantity >= 4)
            {
                double discount = totalCost * 0.15;
                totalCost = totalCost - discount;
            }
            if(totalCost == 0)
            {
                totalCost = 1000;
            }
            totalCostLabel.Text = "$" + totalCost;
        }
        void updatePerUnitCost()
        {
            perUnitCost = upgradeCost + baseUnitCost;
            perUnitCostLabel.Text = "$" + (upgradeCost + baseUnitCost);
        }
        async void OnAlertYesNoClicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Verification", "The total cost is: " + totalCostLabel.Text + " Do you want to purchase?", "Yes", "No");
            if(answer==true)
            {
                clearScreen();
                DisplayAlert("Successful!", "Your items are on their way!", "Yay!");
            }
        }
        void clearScreen()
        {
            nameEntry.Text = "";
            emailEntry.Text = "";
            phoneEntry.Text = "";
            sliderMain.Value = 0;
            computerPicker.SelectedIndex = 0;
            memorySwitch.IsToggled = false;
            officeSwitch.IsToggled = false;
            appleTvSwitch.IsToggled = false;
            perUnitCost = 1000;
            updateTotalCost();

        }
    }
}
