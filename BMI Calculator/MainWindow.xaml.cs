using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BMI_Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BMI _bmi = new BMI();
        public MainWindow()
        {
            InitializeComponent();
            lblAge.Content = _bmi.Age;
            lblWeight.Content =_bmi.Weight; 
        }
        //genders
        private void imgMale_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _bmi.Gender = Gender.MALE;
        }

        private void imgFemale_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _bmi.Gender = Gender.FEMALE;
        }
        //slider 
        private void sldrHeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _bmi.Height = sldrHeight.Value;
            lblHeight.Content = _bmi.Height.ToString("F1");
        }
        // weight increase or dec
        private void imgMinusWeight_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _bmi.Weight -= 0.5;
            lblWeight.Content = _bmi.Weight.ToString("F1");
        }

        private void imgAddWeight_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _bmi.Weight += 0.5;
            lblWeight.Content = _bmi.Weight.ToString("F1");
        }
        // Age increase or dec
        private void imgMinusAge_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _bmi.Age--;
            lblAge.Content = _bmi.Age;
        }

        private void imgAddAge_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _bmi.Age++;
            lblAge.Content = _bmi.Age;
        }

        private void btnCalulate_Click(object sender, RoutedEventArgs e)
        {
            lblBmi.Content = _bmi.ToString();
        }
    }
    public enum Gender
    {
        MALE,
        FEMALE
    }
    public class BMI
    {

        private double weight = 70;
        private double height;
        private int age = 20;
        public Gender Gender { get; set; }
        public double Weight 
        { 
            get => weight;
            set
            {
              
                if (value < 0)
                {
                    weight = 0;
                }
                else
                {
                    weight = value;
                }
            }
        }
        public double Height 
        {
            get => height;
            set
            {
                if (value < 0)
                {
                    height = 0;
                }
                else
                {
                    height = value;
                }
            }
        }
        public int Age
        {
            get => age;
            set => age = value;
        }

        public double CalculateBmi() => Weight / ((Height * Height) /100) *100;
        public override string ToString() => CalculateBmi().ToString("F2");
    }
}
