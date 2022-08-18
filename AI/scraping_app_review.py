from google_play_scraper import Sort, reviews_all
import pandas as pd
import numpy as np

result = reviews_all(
    'com.icandesignapp.all',
    sleep_milliseconds=0, # defaults to 0
    lang='kr', # defaults to 'en'
    country='kr', # defaults to 'us'
    count= 3,
    sort=Sort.MOST_RELEVANT, # defaults to Sort.MOST_RELEVANT
    filter_score_with= 0 # defaults to None(means all score)
)

df_busu = pd.DataFrame(np.array(result), columns=['review'])
df_busu = df_busu.join(pd.DataFrame(df_busu.pop('review').tolist()))

df_busu.head()
