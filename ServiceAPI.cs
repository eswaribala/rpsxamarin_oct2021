public class APIService
    {
        private HttpClient httpClient;
        public ObservableCollection<MedicalCollege> MedicalColleges { get; set; }
        public String WebAPIUrl { get; set; }
        public APIService()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<ObservableCollection<MedicalCollege>> RefreshAsyncData()
        {
            WebAPIUrl = "https://api.rootnet.in/covid19-in/hospitals/medical-colleges"; // Set your REST API url here
            var uri = new Uri(WebAPIUrl);
            try
            {
                var response = await httpClient.GetAsync(uri);

                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Verify.....................");
                JObject jObject = JObject.Parse(content);
                
                Console.WriteLine(jObject["data"]["medicalColleges"]);
                MedicalColleges = JsonConvert.DeserializeObject<ObservableCollection<MedicalCollege>>(jObject["data"]["medicalColleges"].ToString());
                Console.WriteLine("Verify.....................");
                Console.WriteLine("City" + MedicalColleges[0].City);
                return MedicalColleges;

            }
            catch(Exception ex)
            {

            }
            return null;
        }

    }
