# WEATHER APP

Project by __MACE__ Léo, __ARCAS__ Manon and __DE AMEZAGA__ Bastien

## _Table of contents:_

I.[Project description](#i-project-description)

II. [available features ](#ii-available-features-)

III. [How to install the project](#iii-how-to-install-the-project)

IV. [How to launch the project](#iv-how-to-launch-the-project)
1. [Launch the app](#launch-the-app)
2. [Browse the app](#browse-the-app)

## I. Project description

Weather App is a project whose goal was to create an weather app in c sharpe language and Avalonia using API datas.

## II. Available features 

- #### 3 pages :
    - Home
    - Search
    - Settings

- #### Search bar
- #### Default city
- #### Multilanguage

## III. How to install the project


```bash
git clone https://ytrack.learn.ynov.com/git/mleo/WeatherApp.git
```

Add ```config.json``` file and a this content :

```json
{
  "api_Key": "your_api_key"
}
```

Then if you didn't have 'Json' folder create it.

## IV. How to launch the project

### Launch the App

```bash
cd WeatherApp
dotnet run
```

### Browse the app
At the start of the app, there is a charging page about 2 seconds before getting the home display.

All of the pages have a navbar on which 3 categories are available: settings, home and search to help users to find any informations.

On the main page we can see the actual weather of the default city as well as the forecast for the next 5 days.

On the search pages the users can access to a search bar to find the city whose weather he wants to know. It will return a list of city with a brief overview of the actual weather.
All of these results are clickables, you will be redirected to a page with the same pattern as the home page. 

On the setting page, the users can modify the default city and the language of the app.


😉**We hope you will enjoy your user experience !** 