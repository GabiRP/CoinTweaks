# CoinTweaks

This EXILED plugin adds more features (currently 2) for Coins

[![Github All Releases](https://img.shields.io/github/downloads/GabiRP/CoinTweaks/total?color=red&style=for-the-badge)]()

# Features
* Chance of dropping a coin when flipping it
* A message (broadcast/hint) showing the coin flip result (heads/tails)

# Config
```yml
coin_tweaks:
# Whether or not this plugin is enabled.
  is_enabled: true
  # Whether or not debug mode is enabled
  debug: false
  # Whether broadcast should be replaced with hints
  use_hints: true
  # Chance of dropping a coin while flipping it (set to 0 to disable)
  drop_coin_chance: 20
  # Time before dropping the coin
  drop_coin_time: 1
  # Duration of drop_coin_message
  drop_coin_message_duration: 6
  # Whether a message should be sent or not telling the player his coin flip result (head/tails)
  show_coin_result_message: true
  # Time before showing the result
  coin_result_time: 1.79999995
  # Duration of the above hint/message
  coin_result_message_duration: 1
  ```
  # Translations ({port}-translations.yml)
  ```yml
coin_tweaks:
# Coin result broadcast/hint (if the above config is true) %result% will be replaced with the flip result
  coin_result_message: 'Coin result:'
  # Dropping coin broadcast/hint
  drop_coin_message: You accidentaly dropped your coin while flipping it
  # Heads translation
  heads_translation: Heads
  # Tails translation
  tails_translation: Tails
  ```
  
  Plugin demostration:
  [![1632219676-medaltvscpsecretlaboratory20210921120916-tr-edit](https://user-images.githubusercontent.com/57387907/134155458-dd27432e-db40-4b19-8b34-6211349a3e54.gif)](https://medal.tv/clips/65556491/d1337p5lbhT1)
