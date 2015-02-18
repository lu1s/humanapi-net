using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using HumanAPI.DataModel;

namespace HumanAPI
{
    public class Manager
    {
        private static Manager _instance;
        //private readonly Uri _baseUrl = new Uri("http://humanapi.co/v1/human/");
        private readonly Uri _baseUrl = new Uri("https://user.humanapi.co/v1/human/");
        private String token = "";

        public Manager()
        {
            _instance = this;
        }
        public Manager(String t)
        {
            _instance = this;
            token = t;
        }
        private static Manager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                return _instance = new Manager();
            }
        }
        public static Manager GetInstance()
        {
            return Instance;
        }
        public void SetToken(String humanApiToken)
        {
            token = humanApiToken;
        }
        private String MakeWebRequest(String command)
        {
            return MakeWebRequest(command, token);
        }
        private String MakeWebRequest(String command, String humanApiToken)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(_baseUrl + command),
                Method = HttpMethod.Get
            };
            request.Headers.Add("Authorization", String.Format("Bearer {0}", humanApiToken));
            var stringObject = "";
            var task = client.SendAsync(request).ContinueWith((taskwithmsg) =>
            {
                var response = taskwithmsg.Result;
                var stringTask = response.Content.ReadAsStringAsync();
                stringTask.Wait();
                stringObject = stringTask.Result;
            });
            task.Wait();
            return stringObject;
        }
        private T Objectify<T>(String response)
        {
            return JsonConvert.DeserializeObject<T>(response);
        }

        public Profile GetProfile()
        {
            var response = MakeWebRequest("profile");
            return Objectify<Profile>(response);
        }

        public Summary GetSummary()
        {
            var response = MakeWebRequest("");
            return Objectify<Summary>(response);
        }

        public Activity GetRecentActivitySummary()
        {
            var response = MakeWebRequest("activity");
            return Objectify<Activity>(response);
        }

        public Activity GetActivitySummaryByDate(DateTime date)
        {
            var response = MakeWebRequest("activity/daily/" + date.ToString("u").Split(' ').First());
            return Objectify<Activity>(response);
        }

        public Activity GetActivitySeries()
        {
            var response = MakeWebRequest("activity/series");
            return Objectify<Activity>(response);
        }

        public Activity GetActivitySeriesByDate(DateTime date)
        {
            var response = MakeWebRequest("activity/series/" + date.ToString("u").Split(' ').First());
            return Objectify<Activity>(response);
        }
        //Glucose
        public List<BloodGlucose> GetRecentGlucose()
        {
            var response = MakeWebRequest("blood_glucose");
            return Objectify<List<BloodGlucose>>(response);
        }

        public BloodGlucose GetGlucoseByDate(DateTime date)
        {
            return GetGlucoseByDate(date.ToString("u").Split(' ').First());
        }

        public BloodGlucose GetGlucoseByDate(String date)
        {
            var response = MakeWebRequest("blood_glucose/daily/" + date);
            return Objectify<BloodGlucose>(response);
        }

        public List<BloodGlucose> GetGlucoseReadings()
        {
            var response = MakeWebRequest("blook_glucose/readings");
            return Objectify<List<BloodGlucose>>(response);
        }

        public BloodGlucose GetGlucoseById(int id)
        {
            var response = MakeWebRequest("blood_glucose/" + id);
            return Objectify<BloodGlucose>(response);
        }
        //BloodPressure
        public List<BloodPressure> GetRecentBloodPressure()
        {
            var response = MakeWebRequest("blood_pressure");
            return Objectify<List<BloodPressure>>(response);
        }

        public BloodPressure GetBloodPressureByDate(DateTime date)
        {
            return GetBloodPressureByDate(date.ToString("u").Split(' ').First());
        }

        public BloodPressure GetBloodPressureByDate(String date)
        {
            var response = MakeWebRequest("blood_pressure/daily/" + date);
            return Objectify<BloodPressure>(response);
        }

        public BloodPressure GetBloodPressureById(int id)
        {
            var response = MakeWebRequest("blood_pressure/" + id);
            return Objectify<BloodPressure>(response);
        }
        //Bmi
        public List<Bmi> GetRecentBmi()
        {
            var response = MakeWebRequest("bmi");
            return Objectify<List<Bmi>>(response);
        }

        public List<Bmi> GetBmiByDate(DateTime date)
        {
            return GetBmiByDate(date.ToString("u").Split(' ').First());
        }

        public List<Bmi> GetBmiByDate(String date)
        {
            var response = MakeWebRequest("bmi/daily/" + date);
            return Objectify<List<Bmi>>(response);
        }

        public Bmi GetBmiById(int id)
        {
            var response = MakeWebRequest("bmi/" + id);
            return Objectify<Bmi>(response);
        }
        //Body_fat
        public List<BodyFat> GetRecentBodyFat()
        {
            var response = MakeWebRequest("body_fat");
            return Objectify<List<BodyFat>>(response);
        }

        public List<BodyFat> GetBodyFatByDate(DateTime date)
        {
            return GetBodyFatByDate(date.ToString("u").Split(' ').First());
        }

        public List<BodyFat> GetBodyFatByDate(String date)
        {
            var response = MakeWebRequest("body_fat/daily/" + date);
            return Objectify<List<BodyFat>>(response);
        }

        public BodyFat GetBodyFatById(int id)
        {
            var response = MakeWebRequest("body_fat/" + id);
            return Objectify<BodyFat>(response);
        }
        //HeartRate
        public List<HeartRate> GetRecentHeartRate()
        {
            var response = MakeWebRequest("heart_rate");
            return Objectify<List<HeartRate>>(response);
        }

        public HeartRate GetHeartRateByDate(DateTime date)
        {
            return GetHeartRateByDate(date.ToString("u").Split(' ').First());
        }

        public HeartRate GetHeartRateByDate(String date)
        {
            var response = MakeWebRequest("heart_rate/daily/" + date);
            return Objectify<HeartRate>(response);
        }

        public HeartRate GetHeartRateById(int id)
        {
            var response = MakeWebRequest("heart_rate/" + id);
            return Objectify<HeartRate>(response);
        }
        //Height
        public List<Height> GetRecentHeight()
        {
            var response = MakeWebRequest("height");
            return Objectify<List<Height>>(response);
        }

        public Height GetHeightByDate(DateTime date)
        {
            return GetHeightByDate(date.ToString("u").Split(' ').First());
        }

        public Height GetHeightByDate(String date)
        {
            var response = MakeWebRequest("height/daily/" + date);
            return Objectify<Height>(response);
        }

        public Height GetHeightById(int id)
        {
            var response = MakeWebRequest("height/" + id);
            return Objectify<Height>(response);
        }
        //Location
        public List<Location> GetRecentLocations()
        {
            var response = MakeWebRequest("location");
            return Objectify<List<Location>>(response);
        }

        public List<Location> GetLocationByDate(DateTime date)
        {
            return GetLocationByDate(date.ToString("u").Split(' ').First());
        }

        public List<Location> GetLocationByDate(String date)
        {
            var response = MakeWebRequest("location/daily/" + date);
            return Objectify<List<Location>>(response);
        }
        //Sleep
        public List<Sleep> GetRecentSleep()
        {
            var response = MakeWebRequest("sleep");
            return Objectify<List<Sleep>>(response);
        }

        public List<Sleep> GetSleepByDate(DateTime date)
        {
            return GetSleepByDate(date.ToString("u").Split(' ').First());
        }

        public List<Sleep> GetSleepByDate(String date)
        {
            var response = MakeWebRequest("sleep/daily/" + date);
            return Objectify<List<Sleep>>(response);
        }

        public Sleep GetSleepById(int id)
        {
            var response = MakeWebRequest("sleep/" + id);
            return Objectify<Sleep>(response);
        }
        //Weight
        public List<Weight> GetRecentWeight()
        {
            var response = MakeWebRequest("weight");
            return Objectify<List<Weight>>(response);
        }

        public List<Weight> GetWeightByDate(DateTime date)
        {
            return GetWeightByDate(date.ToString("u").Split(' ').First());
        }

        public List<Weight> GetWeightByDate(String date)
        {
            var response = MakeWebRequest("weight/daily/" + date);
            return Objectify<List<Weight>>(response);
        }

        public Weight GetWeightById(int id)
        {
            var response = MakeWebRequest("weight/" + id);
            return Objectify<Weight>(response);
        }



    }

}
