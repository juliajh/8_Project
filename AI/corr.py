#-*- coding: utf-8 -*-
import os
import sys
import urllib.request
import json
import re
from collections import Counter
from matplotlib import font_manager, rc
from wordcloud import WordCloud
from konlpy.tag import Okt
import matplotlib.pyplot as plt
import nltk
from nltk.corpus import stopwords
from nltk import Text

okt = Okt()

with open('craw_text.txt', 'r', encoding='utf-8') as file:
    x = file.read()

tmp_list = okt.pos(x, norm=True, stem=True)
myList_filter = [x for x, y in tmp_list if y in ['Noun']]
count = Counter(myList_filter)
print(count)

# words = (dict(count.most_common()))
# Okt = Text(myList_filter, name="Okt")
# wordInfo = dict()
# for tags, counts in Okt.vocab().most_common(20):
#     if (len(str(tags)) > 1):
#         wordInfo[tags] = counts
# values = sorted(wordInfo.values(), reverse=True)
# keys = sorted(wordInfo, key=wordInfo.get, reverse=True)

# #오류 방지 폰트 설정
# font_location = "malgun.ttf"
# font_name = font_manager.FontProperties(fname=font_location).get_name()
# rc('font', family=font_name)
#
# # plt 그래프
# plt.bar(range(len(wordInfo)), values, align='center')
# plt.xticks(range(len(wordInfo)), list(keys), rotation='70')
# plt.show()
#
# # wordcloud
# wc = WordCloud(width = 1000, height = 600, background_color="white", font_path=font_location, max_words=50)
# plt.imshow(wc.generate_from_frequencies(Okt.vocab()))
# plt.axis("off")
# plt.show()