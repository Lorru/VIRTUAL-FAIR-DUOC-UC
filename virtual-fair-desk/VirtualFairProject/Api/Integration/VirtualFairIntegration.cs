using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using VirtualFairProject.Api;
using VirtualFairProject.Class;
using Newtonsoft.Json;
using System.Dynamic;

namespace VirtualFairProject.Api.Integration
{
    public class VirtualFairIntegration
    {

        static string URL_VIRTUAL_FAIR_USER = ConfigurationManager.AppSettings.Get("UserApiToken");
        static string URL_VIRTUAL_FAIR_PRODUCT = ConfigurationManager.AppSettings.Get("Product");
        static string URL_VIRTUAL_FAIR_PURCHASEREQUEST = ConfigurationManager.AppSettings.Get("PurchaseRequestApi");
        static string URL_VIRTUAL_FAIR_PURCHASEREQUESTPRODUCT = ConfigurationManager.AppSettings.Get("PurchaseRequestProduct");
        static string URL_VIRTUAL_FAIR_PROFILE = ConfigurationManager.AppSettings.Get("Profile");
        static string URL_VIRTUAL_FAIR_PURCHASEREQUESTREMARK = ConfigurationManager.AppSettings.Get("PurchaseRequestRemark");
        static string URL_VIRTUAL_FAIR_TRANSPORTAUCTION = ConfigurationManager.AppSettings.Get("TransportAuction");
        static string URL_VIRTUAL_FAIR_PURCHASEREQUESTPRODUCER = ConfigurationManager.AppSettings.Get("PurchaseRequestProducer");
        static string URL_VIRTUAL_FAIR_PURCHASEREQUESTSTATUS = ConfigurationManager.AppSettings.Get("PurchaseRequestStatus");
        



        public VirtualFairIntegration() { }

        #region ApiLogin
        public static dynamic ApiLogin(string email, string password)
        {
            //POST
            Profile profile = new Profile { id = 0, name = "string" };

            AdminApi admApi = new AdminApi
            {
                address = "string",
                city = "string",
                country = "string",
                email = email,
                fullName = "string",
                id = 0,
                idProfile = 0,
                password = password,
                profile = profile,
                status = 0
            };

            var url = URL_VIRTUAL_FAIR_USER;
            var urlMethod = "findByEmailAndPassword";
            WebAPIClient clientAPI = new WebAPIClient(url);
            var paramApi = urlMethod;
            var content = JsonConvert.SerializeObject(admApi);
            var body = new StringContent(content, Encoding.UTF8, UtilWebApiMethod.TypeJson);
            var response = clientAPI.HttpClient.PostAsync(paramApi, body);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }
        #endregion



        #region Products
        public static dynamic FindAllProducts(string token)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_PRODUCT;
            var urlMethod = "findAll";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = urlMethod;
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);
           
            return result;
        }
        #endregion

        #region StatusCombobox

        public static dynamic FindAllStatus(string token)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_PURCHASEREQUESTSTATUS;
            var urlMethod = "findAll";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = urlMethod;
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        #endregion

        #region Administrator


        public static dynamic createTransportAuction(string token, dynamic objectCreate)
        {
            //POST
            var url = URL_VIRTUAL_FAIR_TRANSPORTAUCTION;
            var urlMethod = "create";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);
            var paramApi = urlMethod;
            var content = JsonConvert.SerializeObject(objectCreate);
            var body = new StringContent(content, Encoding.UTF8, UtilWebApiMethod.TypeJson);
            var response = clientAPI.HttpClient.PostAsync(paramApi, body);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        //findAll - Servicio para obtener una lista de todas las subasta de transporte
        public static dynamic GetFindAllAuctionsAdmin(string token)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_TRANSPORTAUCTION;
            var urlMethod = "findAll";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = urlMethod;
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        //Servicio para obtener una lista de todas las subasta de transporte que no estan publicadas
        public static dynamic GetFindByIsPublicEqualToZeroAdmin(string token)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_TRANSPORTAUCTION;
            var urlMethod = "findByIsPublicEqualToZero";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = urlMethod;
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        //Servicio para obtener una lista de todas las subasta de transporte que estan publicadas
        public static dynamic GetFindByIsPublicEqualToOneAdmin(string token)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_TRANSPORTAUCTION;
            var urlMethod = "findByIsPublicEqualToOne";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = urlMethod;
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }


        public static dynamic GetFindByIdPurchaseRequest(string token, dynamic parameters)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_PURCHASEREQUESTPRODUCER;
            var urlMethod = "findByIdPurchaseRequest";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = String.Concat(urlMethod,"/", parameters.idPurchaseRequest);
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }
        public static dynamic AdminUpdateIsPublicById(string token, dynamic objectUpdate)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_PURCHASEREQUEST;
            var urlMethod = "updateIsPublicById";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = String.Concat(urlMethod, "/", objectUpdate.id);
            var content = JsonConvert.SerializeObject(objectUpdate);
            var body = new StringContent(content, Encoding.UTF8, UtilWebApiMethod.TypeJson);
            var response = clientAPI.HttpClient.PutAsync(paramApi, body);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        public static dynamic GetFindByIsPublicEqualToOne(string token)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_PURCHASEREQUEST;
            var urlMethod = "findByIsPublicEqualToOne";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = urlMethod;
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        public static dynamic GetFindByIsPublicEqualToZero(string token)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_PURCHASEREQUEST;
            var urlMethod = "findByIsPublicEqualToZero";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = urlMethod;
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }
        public static dynamic GetFindAllPurchaseRequisitions(string token)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_PURCHASEREQUEST;
            var urlMethod = "findAll";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = urlMethod;
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        public static dynamic GetFindByIdPurchaseRequestStatusAndIdPurchaseRequestType(string token, dynamic parameters)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_PURCHASEREQUEST;
            var urlMethod = "findByIdPurchaseRequestStatusAndIdPurchaseRequestType";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = String.Concat(urlMethod, "/", parameters.idPurchaseRequestStatus, "/", parameters.idPurchaseRequestType);
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        #endregion


        #region Producer

        public static dynamic ProducerFindByIdPurchaseRequest(string token, dynamic parameters)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_PURCHASEREQUESTPRODUCER;
            var urlMethod = "findByIdPurchaseRequest";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = String.Concat(urlMethod, "/", parameters.idPurchaseRequestType);
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        public static dynamic ProducerFindByIdPurchaseRequestAndIdProducer(string token, dynamic parameters)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_PURCHASEREQUESTPRODUCER;
            var urlMethod = "findByIdPurchaseRequestAndIdProducer";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = String.Concat(urlMethod, "/", parameters.idPurchaseRequestType, "/", parameters.idProducer);
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        public static dynamic FindByIdPurchaseTypeAndIdProducer(string token, dynamic parameters)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_PURCHASEREQUEST;
            var urlMethod = "findByIdPurchaseRequestTypeAndIdProducerAndIsPublicEqualToOne";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = String.Concat(urlMethod,"/", parameters.idPurchaseRequestType,"/", parameters.idProducer);
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        public static dynamic FindByIdPurchaseRequestTypeAndIsPublicEqualToOne(string token, dynamic parameters)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_PURCHASEREQUEST;
            var urlMethod = "findByIdPurchaseRequestTypeAndIsPublicEqualToOne";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = String.Concat(urlMethod, "/", parameters.idPurchaseRequestType);
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        #endregion

        #region Carrier

        public static dynamic FindByIdCarrierAndIsPublicEqualToOne(string token, dynamic parameters) 
        {
            //GET
            var url = URL_VIRTUAL_FAIR_TRANSPORTAUCTION;
            var urlMethod = "findByIdCarrierAndIsPublicEqualToOne";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = String.Concat(urlMethod, "/", parameters.idCarrier);
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }


        #endregion 

        #region InternalCustomer


        public static dynamic FindByIdPurchaseRequest(string token, string idPurchaseRequest)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_PURCHASEREQUESTPRODUCT;
            var urlMethod = "findByIdPurchaseRequest";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = String.Concat(urlMethod, "/", idPurchaseRequest);
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        public static dynamic UpdateStatusById(string token, dynamic purchaseRequest)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_PURCHASEREQUEST;
            var urlMethod = "updateStatusById";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = String.Concat(urlMethod, "/", purchaseRequest.id);
            var content = JsonConvert.SerializeObject(purchaseRequest);
            var body = new StringContent(content, Encoding.UTF8, UtilWebApiMethod.TypeJson);
            var response = clientAPI.HttpClient.PutAsync(paramApi, body);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        public static dynamic CreateRemark(string token, dynamic client)
        {
            //POST
            var url = URL_VIRTUAL_FAIR_PURCHASEREQUESTREMARK;
            var urlMethod = "create";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);
            var paramApi = urlMethod;
            var content = JsonConvert.SerializeObject(client);
            var body = new StringContent(content, Encoding.UTF8, UtilWebApiMethod.TypeJson);
            var response = clientAPI.HttpClient.PostAsync(paramApi, body);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        public static dynamic FindByIdClient(string token, int idClient)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_PURCHASEREQUEST;
            var urlMethod = "findByIdClient";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = String.Concat(urlMethod,"/",idClient);
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        public static dynamic CreateNewPurchaseRequest(string token, dynamic objectAPI)
        {
            //POST
            

            var url = URL_VIRTUAL_FAIR_PURCHASEREQUEST;
            var urlMethod = "create";
            WebAPIClient clientAPI = new WebAPIClient(url);

            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = urlMethod;
            var content = JsonConvert.SerializeObject(objectAPI);
            var body = new StringContent(content, Encoding.UTF8, UtilWebApiMethod.TypeJson);
            var response = clientAPI.HttpClient.PostAsync(paramApi, body);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        #endregion

        #region Users
        public static dynamic GetFindAllUser(string token)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_USER;
            var urlMethod = "findAll";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = urlMethod;
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }


        public static dynamic CreateUser(string token, dynamic user)
        {
            //POST

            var url = URL_VIRTUAL_FAIR_USER;
            var urlMethod = "create";
            WebAPIClient clientAPI = new WebAPIClient(url);

            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = urlMethod;
            var content = JsonConvert.SerializeObject(user);
            var body = new StringContent(content, Encoding.UTF8, UtilWebApiMethod.TypeJson);
            var response = clientAPI.HttpClient.PostAsync(paramApi, body);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        public static dynamic UpdateById(string token, dynamic user)
        {
            //PUT

            var url = URL_VIRTUAL_FAIR_USER;
            var urlMethod = "updateById";
            WebAPIClient clientAPI = new WebAPIClient(url);

            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = String.Concat(urlMethod, "/", user.id);
            var content = JsonConvert.SerializeObject(user);
            var body = new StringContent(content, Encoding.UTF8, UtilWebApiMethod.TypeJson);
            var response = clientAPI.HttpClient.PutAsync(paramApi, body);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        public static dynamic UserUpdateStatusById(string token, dynamic user)
        {
            //PUT

            var url = URL_VIRTUAL_FAIR_USER;
            var urlMethod = "updateStatusById";
            WebAPIClient clientAPI = new WebAPIClient(url);

            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = String.Concat(urlMethod, "/", user.id);
            var content = JsonConvert.SerializeObject(user);
            var body = new StringContent(content, Encoding.UTF8, UtilWebApiMethod.TypeJson);
            var response = clientAPI.HttpClient.PutAsync(paramApi, body);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        #endregion

        #region Profile

        public static dynamic GetFindAllProfiles(string token)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_PROFILE;
            var urlMethod = "findAll";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = urlMethod;
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        public static dynamic GetFindAllUsers(string token)
        {
            //GET
            var url = URL_VIRTUAL_FAIR_USER;
            var urlMethod = "findAll";
            WebAPIClient clientAPI = new WebAPIClient(url);
            //era necesario un Authorization
            clientAPI.HttpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(token);

            var paramApi = urlMethod;
            var response = clientAPI.HttpClient.GetAsync(paramApi);
            var result = clientAPI.Deserialize<dynamic>(response.Result);

            return result;
        }

        #endregion

    }
}
