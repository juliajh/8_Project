import time
from selenium import webdriver
from selenium.webdriver import Keys
from selenium.webdriver.common.by import By
from webdriver_manager.chrome import ChromeDriverManager
from selenium.webdriver.chrome.service import Service
from bs4 import BeautifulSoup
import os
import sys
import urllib.request
import json
import re
from collections import Counter
import WordCloud



client_id = "bdpWYU7e70Thq9gFsYAU"
client_secret = "9JU2hmkHTD"

def make_blog_craw_link(word, num):
    num = num * 100 + 1
    encText = urllib.parse.quote(word)
    url = "https://openapi.naver.com/v1/search/blog?query=" + encText +"&display=10"+"&start="+str(num) # json 결과
    body = "{\"startDate\":\"2017-01-01\",\"endDate\":\"2017-04-30\",\"timeUnit\":\"month\",\"keywordGroups\":[{\"groupName\":\"한글\",\"keywords\":[\"한글\",\"korean\"]},{\"groupName\":\"영어\",\"keywords\":[\"영어\",\"english\"]}],\"device\":\"pc\",\"ages\":[\"1\",\"2\"],\"gender\":\"f\"}";

    request = urllib.request.Request(url)
    request.add_header("X-Naver-Client-Id", client_id)
    request.add_header("X-Naver-Client-Secret", client_secret)
    response = urllib.request.urlopen(request)
    rescode = response.getcode()

    if (rescode == 200):
        response_body = response.read()
        response_body = json.loads(response_body)
        result_data = response_body['items']
        #de_list = []
        de_list_link = []
        for index, item in enumerate(response_body['items']):
            #tmp_data = re.sub(r'[0-9|<|>|b|\/]+', '', item['description'])
            tmp_data_link = item['link']
            #de_list.append(tmp_data)
            de_list_link.append(tmp_data_link)
    else:
        print("Error Code:" + rescode)

    return de_list_link

def craw_blog_text_from_link(data):
    totallist = []
    cnt = 0
    tmp_url = data
    for i in range(len(tmp_url)):
        tmp = tmp_url[i]
        chrome_options = webdriver.ChromeOptions()
        chrome_options.add_experimental_option("detach", True)
        driver = webdriver.Chrome(service=Service(ChromeDriverManager().install()),options=chrome_options)
        driver.maximize_window()
        driver.get(tmp)
        time.sleep(1)
        try:
            driver.switch_to.frame('mainFrame')
            text = driver.find_element(By.CSS_SELECTOR, 'div.se-main-container').text
            totallist.append(text)
            cnt += 1
        except:
            cnt += 1
            pass

        print(cnt)
        driver.close()

    return totallist

word = '오늘의집 3D'
num = 1
#WordCloud.make_wordcloud_graph(craw_blog_text_from_link(make_blog_craw_link(word, 1)))
craw_blog_text_from_link(make_blog_craw_link(word, num))



import os

f = open('craw_text.txt','r')

print(f)