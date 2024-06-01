using apiweb.Client;
using apiweb.Data;
using apiweb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebApi.Client;

namespace apiweb.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MyBirdController : Controller
    {
        private readonly MyBirdAppDbContext _appContext;
        public MyBirdController(MyBirdAppDbContext AppContext)
        {
            _appContext = AppContext;
        }

        [HttpGet]
        [ActionName("RandomPhotoOfBird")]
        public async Task<ActionResult<string>> RandomPhotoOfBird()
        {
            PhotoClient photoclient = new PhotoClient();
            string response = photoclient.GetRandomBirdPhoto().Result;
            return response;
            
        }

        [HttpGet]
        [ActionName("ObservByRegionCode")]
        public async Task<ActionResult<string>> ListforaRegionCode(string regionCode)
        {
            ObservationsClient birdClient = new ObservationsClient();
            string response = birdClient.GetObservforaRegionCode(regionCode).Result;
            return response;
        }

        [HttpGet]
        [ActionName("GetRegionList")]
        public async Task<ActionResult<string>> GetRegion()
        {
            string listofregion = " ";
            var list = await _appContext.RegionsUkraie.FromSql($"select * from dbo.RegionsUkraie").ToListAsync();
            foreach (var region in list)
            {
                listofregion = $"{listofregion}\n{region.RegionName} — {region.RegionCode}";
            }
            return listofregion;

        }

        [HttpGet]
        [ActionName("GetMyOwnObservList")]
        public async Task<ActionResult<string>> GetObservList(long PersonChatId)
        {
            string ListOfMyObserv = " ";
            var observations = await _appContext.OwnListOfObservationsInfo.FromSql($"select * from dbo.OwnListOfObservationsInfo  where chatId = {PersonChatId};").ToListAsync();

            if (observations.Count == 0)
            {
                return "Ваш лист спостережень пустий";
            }
            foreach (var observation in observations)
            {
                ListOfMyObserv = ListOfMyObserv + "\nId:" + observation.Id + ".\nНазва: " + observation.sciName + ".\nМiсце,в якому спостерігалось: " + observation.locName + "\nДата: " + observation.obsDt + "\nКількість: " + observation.howMany + "\n ";

            }
            return ListOfMyObserv;
        }

        [HttpPost]
        [ActionName("PostMyObserv")]
        public async Task<string> PostObserv(long PersonChatId, string sciName, string locName, string obsDt, int howMany)
        {
            try
            {
                ObservationsInfo observation = new ObservationsInfo(PersonChatId, sciName, locName, obsDt, Convert.ToInt32(howMany));
                _appContext.OwnListOfObservationsInfo.Add(observation);
                await _appContext.SaveChangesAsync();
                return "`Успішно додано\\!`";
            }
            catch (Exception ex)
            {
                return "`Помилка при запиті, перевірте корректність запису команди (ви ввели цифру на місці кількості?)`";
            }
        }

        [HttpDelete]
        [ActionName("DeleteMyObserv")]
        public async Task<string> DeleteObserv(long PersonChatId, string id)
        {
            try
            {

                    int Id = Convert.ToInt32(id);

               //  await _appContext.OwnListOfObservationsInfo.FromSql($"DELETE FROM dbo.OwnListOfObservationsInfo  where chatId ={PersonChatId} and id={Id};").ToListAsync();

                    await _appContext.OwnListOfObservationsInfo.Where(c => c.Id == Id & c.chatId == PersonChatId).ExecuteDeleteAsync();
                    await _appContext.SaveChangesAsync();
                    return "`Успішно видалено\\!`";              
            }
            catch (Exception ex)
            {
                return "`Помилка при запиті, перевірте корректність запису команди (Введіть іd існуючого елемента, який бажаєте видалити на місці ID в команді)`";
            }
        }
    }
}
