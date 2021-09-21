# CoinTweaks

This plugin adds (at the moment) 2 options for Coins (SCPSL 11.0)

# Config
```yml
coin_tweaks:
# Whether or not this plugin is enabled.
  is_enabled: true
  # Whether or not debug mode is enabled
  debug: true
  # Whether broadcast should be replaced with hints
  use_hints: true
  # Chance of dropping a coin when flipping it
  drop_coin_chance: 20
  # Duration of drop_coin_message
  drop_coin_message_duration: 6
  # Whether a message should be sent or not telling the player his coin flip result (head/tails)
  show_coin_result_message: true
  # Duration of the above hint/message
  coin_result_message_duration: 2
  ```
  # Translations ({port}-translations.yml)
  ```yml
coin_tweaks:
# Coin result broadcast/hint (if the above config is true) {result} will be replaced with the flip result
  coin_result_message: 'Coin result: {result}'
  # Dropping coin broadcast/hint
  drop_coin_message: You accidentaly dropped your coin while flipping it
  # Heads translation
  heads_translation: Heads
  # Tails translation
  tails_tranlation: Tails
  ```
  
  Plugin demostration: [![Demo](https://medal.tv/clips/65556491/d1337wTo9Ivj?invite=cr-MSxWclEsMTgxODI0NTQs)]()
