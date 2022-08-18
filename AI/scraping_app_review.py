from google_play_scraper import Sort, reviews_all

result = reviews_all(
    'com.iCan Design lab.roomplanner',
    sleep_milliseconds=0, # defaults to 0
    lang='kr', # defaults to 'en'
    country='kr', # defaults to 'us'
    sort=Sort.MOST_RELEVANT, # defaults to Sort.MOST_RELEVANT
    filter_score_with=5 # defaults to None(means all score)
)

print(result)