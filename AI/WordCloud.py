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

def get_blog_review(word, num):
    num = num * 100 + 1
    client_id = "bdpWYU7e70Thq9gFsYAU"
    client_secret = "9JU2hmkHTD"

    encText = urllib.parse.quote(word)
    url = "https://openapi.naver.com/v1/search/blog?query=" + encText +"&display=100"+"&start="+str(num) # json 결과
    body = "{\"startDate\":\"2017-01-01\",\"endDate\":\"2017-04-30\",\"timeUnit\":\"month\",\"keywordGroups\":[{\"groupName\":\"한글\",\"keywords\":[\"한글\",\"korean\"]},{\"groupName\":\"영어\",\"keywords\":[\"영어\",\"english\"]}],\"device\":\"pc\",\"ages\":[\"1\",\"2\"],\"gender\":\"f\"}";

    request = urllib.request.Request(url)
    request.add_header("X-Naver-Client-Id",client_id)
    request.add_header("X-Naver-Client-Secret",client_secret)
    response = urllib.request.urlopen(request)
    rescode = response.getcode()


    if(rescode==200):
        response_body = response.read()
        response_body = json.loads(response_body)
        result_data = response_body['items']
        de_list = []
        de_list_link = []
        for index, item in enumerate(response_body['items']):
            tmp_data = re.sub(r'[0-9|<|>|b|\/]+', '', item['description'])
            tmp_data_link = item['link']
            de_list.append(tmp_data)
            de_list_link.append(tmp_data_link)
    else:
        print("Error Code:" + rescode)



    return de_list

def make_revie_list(word):
    review_list = []
    for i in range(0, 10):
        review_list.append(get_blog_review(word, i))
    return review_list


def make_wordcloud_graph(data):
    text_list = []
    for x in range(0, 10):
        for y in range(100):
            tmp = data[x][y]
            myList = okt.pos(tmp, norm=True, stem=True)  # 모든 형태소 추출
            myList_filter = [x for x, y in myList if y in ['Noun']]  # 추출된 값 중 동사만 추출
            text_list.append(myList_filter)
    tmp_list = sum(text_list, [])
    count = Counter(tmp_list)
    words = (dict(count.most_common()))
    Okt = Text(tmp_list, name="Okt")
    wordInfo = dict()
    for tags, counts in Okt.vocab().most_common(50):
        if (len(str(tags)) > 1):
            wordInfo[tags] = counts
    values = sorted(wordInfo.values(), reverse=True)
    keys = sorted(wordInfo, key=wordInfo.get, reverse=True)
    font_location = "malgun.ttf"
    font_name = font_manager.FontProperties(fname=font_location).get_name()
    rc('font', family=font_name)
    plt.bar(range(len(wordInfo)), values, align='center')
    plt.xticks(range(len(wordInfo)), list(keys), rotation='70')
    plt.show()
    wc = WordCloud(width = 1000, height = 600, background_color="white", font_path=font_location, max_words=50)
    plt.imshow(wc.generate_from_frequencies(Okt.vocab()))
    plt.axis("off")
    plt.show()


