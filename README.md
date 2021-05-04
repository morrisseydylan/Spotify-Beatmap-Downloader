# Spotify Beatmap Downloader
A simple WinForms app that allows you to automatically search for osu! beatmaps for songs in your Spotify playlists.
# Work in progress
The app is a work in progress.

Currently the search algorithm only finds beatmaps with exact matches for the artist and title, so oftentimes the app falsely reports that a song doesn't have a beatmap.

Please report any bugs.
# How to use
1. Follow the directions in the app to link your Spotify account.
2. Select the playlist containing the songs for which you want to find beatmaps; then click "Open playlist(s)."
3. Once the songs are done loading, click "Find beatmaps."
4. Add the beatmaps you want to the download queue.
5. Click "Start download." Beatmaps will download to a folder called "downloads" in the same location as the executable.
# Technologies
[SpotifyAPI-NET](https://github.com/JohnnyCrazy/SpotifyAPI-NET)

[Beatconnect API](https://beatconnect.io/api/infos)

[Ookii.Dialogs.WinForms](Ookii.Dialogs.WinForms)

The app originated as a university term project for COP3530. It was written in C++ using [wxWidgets](http://wxwidgets.org/) and [C++ Requests](https://github.com/whoshuu/cpr).
