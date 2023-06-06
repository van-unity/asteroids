# rovio-asteroids
 
here is the link for MacOs build 
https://drive.google.com/file/d/1ocsTYfU4JX5iVJqA5syWFeinrAG01MSU/view?usp=sharing

I wan unable to bind same interface to multiple instances using WithId that's why I'm getting pool instances like this: 

    _bigAsteroidPool = GameObject.FindGameObjectWithTag("BigAsteroidPool")
                    .GetComponent<IPool<IAsteroid>>();
    
whenever i bind interfaces like this: 

                Container.Bind(typeof(IPool<IAsteroid>), typeof(IInitializable))
                .WithId("Big")
                .To<AsteroidPool>()
                .AsCached()
                .NonLazy();
interfaces are not being bound. 

possibly i don't know something, so finding with tag was just a quick solution. 

for ui i didn't create separate module for handling windows but i would do that in a bigger project.
I didn't create controllers/viewmdoels for Ui screens(InitialScreen, GameOverScreen, GameplayScreen) as they were very simple but in a real project i would create them. 

Scripts are divided into 4 main parts. 
    Domain
    Infrastructure
    Application
    Presentation

Domain is the most inner layer and doesn't know about any other layer. 
Infrastructure layer is providing data access, factory and pool implementations. 
Application layer contains main gameplay logic
Presentation layer is everything that is visible to the user. 

for the input if it was a bigger project i would possibly implement commands.

there is only one installer but of course if it was a big project i would divide it to smaller ones. 

here are some Unity features that are used: 
    Addressables
    Nested Prefabs
    Assembly Definitions 

