# MFCD 2.0
A rewrite of the old project!

**M**ass **F**urry **C**ontent **D**ownloader (MFCD) is a CLI tool to download furry content en masse. 

Right now, it only supports fetching content from [e621.net](https://e621.net), but more boorus will be supported soon™.


## How do I use it?
Well, you just run the app and let it do it's things

## Setup:
Along with the app, you'll need to create a file called `search.yaml` in the same folder as the application.

You're free to copy [the base yaml file](https://github.com/VelvetThePanda/MFCD_Rewrite/blob/master/MFCD_Rewrite/search.yaml) as well, and edit it to your liking.

# `search.yaml` is __tab-sensitive__.

The example file looks like this:

```yaml
#Make yourself familiar with https://github.com/VelvetThePanda/MFCD_Rewrite
username: <your username here>
key: <your key here>

# This rescriction will be lifted in the future!
search:
  - tags: # all tags are combined per search. 
      - paws
      - big_*
    pages: 2
    folder: pawbs # This is *relative* to the folder the app is in. If you have the app in C:/Users/Me/Desktop, 
                  # It will make a folder in C:/Users/Me/Desktop/ called pawbs, and save all your images there.
                  # 3.0 May save pools into folders. Only time will tell.

  - tags:
      - cute
      - -owo
    pages: 10
```

## It's saying I'm missing username or api key! / It just crashes
If you experience the application suddenly closing, or printing a message reading "you're missing the "x" property in your search.yaml", it's because you are.
If you havent already, you'll need to generate an API key from e621.net.

e621.net -> Account -> Manage API Access -> Token


## *Why* do you need to pass an API Key and your username? 

Well, due to some technical restrictions inposed by e621 regarding their API, it's best to sign in. This restriction may be listed in futher updates, though it's unlikely.


## How do I add more searches?

You can add more searches by copy pasting what you see in the example file

Simply add a newline, and add something like such:
```yaml
  - tags:
      - male
      - solo
      - -human
  pages: 5
```

