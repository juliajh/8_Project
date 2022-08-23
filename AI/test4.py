from tensorflow.keras import models
from tensorflow.keras import layers
from tensorflow.keras import optimizers
from tensorflow.keras import losses
from tensorflow.keras import metrics
from google_play_scraper import Sort, reviews_all
import pandas as pd
import numpy as np
from sklearn.model_selection import train_test_split

app_list = ['com.icandesignapp.all', 'com.planner5d.planner5d', 'fr.anuman.HomeDesign3D']

def make_Dataset(i):
    result = reviews_all(
        i,
        sleep_milliseconds=0,  # defaults to 0
        lang='ko',  # defaults to 'en'
        country='kr',  # defaults to 'us'
        sort=Sort.MOST_RELEVANT,  # defaults to Sort.MOST_RELEVANT
        filter_score_with=0  # defaults to None(means all score)
    )
    return result

def make_DataFrame(data):
    df = pd.DataFrame(np.array(data), columns=['review'])
    df = df.join(pd.DataFrame(df.pop('review').tolist()))

    df = df[['content', 'score']]
    drop_index = df[df['score'] == 3].index
    df = df.drop(drop_index)
    df['label'] = np.where(df['score'] >= 4, 1, 0)
    df = df[['content', 'label']]

    return df


#make_Dataset().to_csv('train.txt', sep='\t')



# def read_data(filename):
#     with open(filename, 'r',encoding='utf-8') as f:
#         data = [line.split('\t') for line in f.read().splitlines()]
#         # txt 파일의 헤더(id document label)는 제외하기
#         data = data[1:]
#     return data
#
# all_data = read_data('train.txt')
#
#
#
#
#
#
#
# model = models.Sequential()
# model.add(layers.Dense(64, activation='relu', input_shape=(100,)))
# model.add(layers.Dense(64, activation='relu'))
# model.add(layers.Dense(1, activation='sigmoid'))
#
# model.compile(optimizer=optimizers.RMSprop(lr=0.001),
#              loss=losses.binary_crossentropy,
#              metrics=[metrics.binary_accuracy])
#
# model.fit(x_train, y_train, epochs=100, batch_size=512)
# results = model.evaluate(x_test, y_test)
#
# model.evaluate(x_test, y_test)