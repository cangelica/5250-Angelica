using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mine.Models;

namespace Mine.Services
{
    public class MockDataStore : IDataStore<ItemModel>
    {
        readonly List<ItemModel> items;

        public MockDataStore()
        {
            items = new List<ItemModel>()
            {
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Cap's shield", Description="Protect against villains", Value = 1 },
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Mjolnir Hammer", Description="Summons lighting and electrocute enemies" ,Value = 5},
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Hawkeye Bow and Arrow", Description="Shoot enemies with high accuracy" ,Value = 2},
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Iron Man's suit", Description="Fly and shoot enemies" , Value = 7},
                new ItemModel { Id = Guid.NewGuid().ToString(), Text = "Infinity Gauntlet", Description="Eliminate half of humanity with a single snap", Value = 10 },   
            };
        }

        public async Task<bool> AddItemAsync(ItemModel item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ItemModel item)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((ItemModel arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<ItemModel> ReadAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ItemModel>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}