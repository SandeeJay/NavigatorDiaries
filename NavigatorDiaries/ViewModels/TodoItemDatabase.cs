using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using static NavigatorDiaries.Views.Search;

namespace NavigatorDiaries.Views
{
    public class TripPlannerDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TripPlannerDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TripPlannerItems>().Wait();
        }

        public Task<List<TripPlannerItems>> GetItemsAsync()
        {
            return database.Table<TripPlannerItems>().ToListAsync();
        }

        

        public Task<List<TripPlannerItems>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<TripPlannerItems>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        }

        public Task<TripPlannerItems> GetItemAsync(int id)
        {
            return database.Table<TripPlannerItems>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(TripPlannerItems item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(TripPlannerItems item)
        {
            return database.DeleteAsync(item);
        }
    }

    //////////////////Journal/////////////
    ///




    public class JournaEntrylItemsDatabase
    {

        readonly SQLiteAsyncConnection database1;

        public JournaEntrylItemsDatabase(string dbPath1)
        {
            database1 = new SQLiteAsyncConnection(dbPath1);
            database1.CreateTableAsync<JournaEntrylItems>().Wait();
        }

        public Task<List<JournaEntrylItems>> GetItemsAsync()
        {

            return database1.QueryAsync<JournaEntrylItems>("SELECT * FROM [JournaEntrylItems] ORDER BY [Date] DESC, [Time] DESC ");
        }

        public Task<List<JournaEntrylItems>> PickEmotionAsync()
        {
            return database1.QueryAsync<JournaEntrylItems>("SELECT DISTINCT [Emotion] FROM [JournaEntrylItems]");
        }

        public Task<List<JournaEntrylItems>> PickLocationAsync()
        {
            return database1.QueryAsync<JournaEntrylItems>("SELECT DISTINCT [City] FROM [JournaEntrylItems]");
        }

        public Task<List<JournaEntrylItems>> PickWeatherAsync()
        {
            return database1.QueryAsync<JournaEntrylItems>("SELECT DISTINCT [Weather] FROM [JournaEntrylItems]");
        }

        public Task<List<JournaEntrylItems>> SearchTestAsync()
        {
            return database1.QueryAsync<JournaEntrylItems>("SELECT * FROM [JournaEntrylItems] WHERE [Emotion]='Happy'");
        }

        public Task<JournaEntrylItems> GetItemAsync(int Entryid)
        {
            return database1.Table<JournaEntrylItems>().Where(i => i.EntryId == Entryid).FirstOrDefaultAsync();
        }


        public Task<int> DeleteItemAsync(JournaEntrylItems Entryitem)
        {
            return database1.DeleteAsync(Entryitem);
        }


        public Task SaveItemAsync(object JournalntryItem)
        {


            return database1.InsertAsync(JournalntryItem);
            /// return database1.QueryAsync<JournaEntrylItems>("SELECT * FROM [JournaEntrylItems] WHERE [Emotion]='Happy'");

        }

        public Task TestEntryAsync(object TestJItem)
        {
            return database1.QueryAsync<JournaEntrylItems>("SELECT DISTINCT [Emotion] FROM [JournaEntrylItems]");

        }
    }


   
    /// <summary>
    /// This Class handels database querrys 
    /// communicate with User Table
    /// </summary>
    public class UserDatabase
    {

        readonly SQLiteAsyncConnection database2;
        /// <summary>
        /// This creates a database if database not avalable
        /// </summary>
        /// <param name="dbPath2"> datbase path</param>
        public UserDatabase(string dbPath2)
        {
            database2 = new SQLiteAsyncConnection(dbPath2);
            database2.CreateTableAsync<User>().Wait();
        }

        /// <summary>
        /// This select user from Username
        /// </summary>
        /// <returns>retuen all user data</returns>
        public Task<List<User>> SelectUserAsync()
        {
            return database2.QueryAsync<User>("SELECT * FROM [User] WHERE [Username]='[UserName]'");
        }
         /// <summary>
         /// This insert and update data to user database
         /// check if userid is avalable
         /// update data if avable
         /// Create new user if not avalable
         /// </summary>
         /// <param name="userID"></param>
         /// <returns></returns>
        public Task<int> SaveUserAsync(User userID)
        {
            if (userID.UserID != 0)
            {
                return database2.UpdateAsync(userID);
            }
            else
            {
                return database2.InsertAsync(userID);
            }
        }
    }




}