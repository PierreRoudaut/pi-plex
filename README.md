# PiPlex

A simple software that watches a download folder and detect common video files 
(.avi | .mkv | .mp4) and move them to their dedicated Plex media folders that you'll specify in the settings.

PiPlex will then try to guess the file duration and move it to the appropriate folder.

* If the video file is less than 70 minutes, it will be moved to your **Plex TV Show Folder**
* If the video file is longer than 70 minutes, it will be moved to your **Plex Movie Folder**

After the file has been moved, PiPlex will update your Plex Media library, launch the Plex Media Server and display a notification once it's done.

On your phone, swipe down to refresh your Plex app and start watching.

## Installation
Got the **release** tab of the project, download and install the latest version of: 
```
PiPlexInstaller.msi
```

## Author

* **Pierre Roudaut** - (https://github.com/PierreRoudaut)

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## Todo

* Write unit test
* Handle (.zip | .rar) large video files
* If the video file is a TV Show, move it to the appropriate folder of the show and the appropriate season subfolder
* Search for subtitles

## Note

The idea of creating such this software came to me by pure laziness. I wanted to avoid getting up and checking the status of my downloads and do this repetitive task for all Plex users that is to move the downloaded files to the appropriate folders and update the Plex library.

You can now focus on downloading and watching your content without having to organize it on Plex.
