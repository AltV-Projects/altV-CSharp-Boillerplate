﻿using AltV.Net;

namespace altV_Boillerplate.Events.ResourceHandler
{
    internal class StartStop : Resource
    {
        public override void OnStart()
        {
            Alt.Log("Server is starting");
            Alt.Log("Testing Database connection...");
            try
            {
                Database.Connection.CanConnect();
                Alt.Log("Database connection successfull!");
            }
            catch (Exception ex)
            {
                Alt.Log($"Could not connect to database, error: {ex.Message}");
            }
        }

        public override void OnStop()
        {
            Alt.Log("Server is shooting down");
        }
    }
}