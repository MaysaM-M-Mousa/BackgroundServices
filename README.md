# BackgroundServices

An small side-project that uses BackgroundService to run period tasks in the background.<br>
We are importing (polling) data from a third party and adding them to the fake database every 10 seconds. 

Some Context:

* HostService and BackgroundServices are normal tasks but they get notified once the app is up and down
* They can be used for polling data from other services as well, and used in listening in case of using message brokers
* If it's a long running task, it's mandatory to handle the logic in asynchrounous manner, otherwise the main thread will get blocked.

references:

* [link1](https://levelup.gitconnected.com/3-ways-to-run-code-once-at-application-startup-in-asp-net-core-bcf45a6b6605)
* [link2](https://edgamat.com/2021/05/30/Background-Polling-Tasks-Using-IHostedService.html)
* [link3](https://medium.com/medialesson/run-and-manage-periodic-background-tasks-in-asp-net-core-6-with-c-578a31f4b7a3)
