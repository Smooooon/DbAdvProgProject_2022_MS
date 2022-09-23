using Microsoft.Win32;
using MusterAG.BusinessLogic.Domain;
using MusterAG.BusinessLogic.Dto;
using MusterAGOrderManagement.Model.Customer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using System.Xml.Serialization;

namespace MusterAGOrderManagement.ViewModel.Customer
{
    internal class ImportCommand : ICommand
    {
        private CustomerViewModel _customerViewModel;
        private CustomerDomain _customerDomain;

        public event EventHandler? CanExecuteChanged;

        public ImportCommand(CustomerViewModel customerViewModel, CustomerDomain customerDomain)
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
            string fileContent;
            IList<CustomerDto> customerDtoList = null;

            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Json files (*.json)|*.json|Xml files (*.xml)|*.xml";
                if (openFileDialog.ShowDialog() == true)
                {
                    fileContent = File.ReadAllText(openFileDialog.FileName);

                    if (openFileDialog.FileName.EndsWith(".xml"))
                    {
                        using (TextReader sr = new StringReader(fileContent))
                        {
                            var serializer = new XmlSerializer(typeof(List<CustomerDto>), new XmlRootAttribute("Kunden"));
                            customerDtoList = (List<CustomerDto>)serializer.Deserialize(sr);
                        }
                    }
                    else if (openFileDialog.FileName.EndsWith(".json"))
                    {
                        using (TextReader sr = new StringReader(fileContent))
                        {
                            customerDtoList = JsonConvert.DeserializeObject<List<CustomerDto>>(fileContent);
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Data type is not supported");
                    }

                    if(customerDtoList == null)
                    {
                        throw new Exception("File konnte nicht deserialisiert werden");
                    }

                    foreach (CustomerDto customerDto in customerDtoList)
                    {
                        customerDto.Address = null;
                        customerDto.AddressId = 1; //Addresse müsste anhand Strasse und PLZ eruiert werden
                        _customerDomain.CreateCustomer(customerDto);
                    }

                    _customerViewModel.RefreshData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Importieren! {ex}");
            }
        }
    }
}
