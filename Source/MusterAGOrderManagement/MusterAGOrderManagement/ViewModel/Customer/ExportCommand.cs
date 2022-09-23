using Microsoft.Win32;
using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Customer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;

namespace MusterAGOrderManagement.ViewModel.Customer
{
    internal class ExportCommand : ICommand
    {
        private CustomerViewModel _customerViewModel;
        private CustomerDomain _customerDomain;

        public event EventHandler? CanExecuteChanged;

        public ExportCommand(CustomerViewModel customerViewModel, CustomerDomain customerDomain)
        {
            _customerViewModel = customerViewModel;
            _customerDomain = customerDomain;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            string filePath = string.Empty;
            IList<CustomerDto> customerDtoList;

            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Json files (*.json)|*.json|Xml files (*.xml)|*.xml";
                bool? test = dialog.ShowDialog();
                if (test == true)
                {
                    filePath = dialog.FileName;
                }

                if(_customerViewModel.DateTimeForTemporal == null)
                    _customerViewModel.DateTimeForTemporal = DateTime.Now;        

                customerDtoList = _customerDomain.GetCustomersTemporal((DateTime)_customerViewModel.DateTimeForTemporal);

                if (filePath.EndsWith(".xml"))
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        var ser = new XmlSerializer(typeof(List<CustomerDto>), new XmlRootAttribute("Kunden"));
                        ser.Serialize(fileStream, customerDtoList);
                    }
                }
                else if (filePath.EndsWith(".json"))
                {
                    using (StreamWriter file = File.CreateText(filePath))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(file, customerDtoList);
                    }                   
                }
                else
                {
                    throw new ArgumentException("Data type is not supported");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Exportieren! {ex}");
            }
        }
    }

    class CsvNameAttribute : Attribute
    {
        public string Name { get; set; }
        CsvNameAttribute(string name) {
        Name = name;
        }
    }
}

//List<Address> addresses = new List<Address> {
//    new Address("Thomas", "Obereggerstrasse 17", "9442", "Berneck"),
//    new Address("Beat", "Hauptstrasse 2", "9000", "St. Gallen"),
//    new Address("Sepp", "Arosastrasse 12", "7000", "Chur")
//};
//Writer.SaveToCsv(addresses, @"C:\Temp\addresses.csv");