# Discord-Bot-Template
A discord bot for NFL Fantasy Football as well as Pick 'Em.

# Discord Set Up
1. You'll need to set up a bot in Discord. You can do that here: https://discordapp.com/developers
1. Click New Application
1. Set up your application using the instructions provided.
1. Once your application is set up, create a new bot from your application.
1. Once your bot is created, copy and set aside your token. You'll need it in the next step.

# Project
1. Clone the project.
1. Set a machine environment variable: ```JAGUAR_Discord__Token``` with the discord token you noted in the last step as the value.
	1. Protip: If on Windows, you can run the following command in Powershell to set environment variables easily. Make sure you subsitute in your key. : ```[Environment]::SetEnvironmentVariable("JAGUAR_Discord__Token", "{your-key}", "User")```
1. You're good to go!

# Run
1. Using your favorite command line interface, ```cd``` to the project's directory.
1. Run ```docker-compose up```
	1. The project currently cannot be debugged using Docker Compose in Visual Studio.
