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



def crawling():
    chrome_options = webdriver.ChromeOptions()
    chrome_options.add_experimental_option("detach", True)
    driver = webdriver.Chrome(service=Service(ChromeDriverManager().install()),options=chrome_options)

    driver.maximize_window()

    driver.get('https://book.naver.com/search/search.nhn?query=%EB%B2%A0%EC%8A%A4%ED%8A%B8%EC%85%80%EB%9F%AC')







client_id = "bdpWYU7e70Thq9gFsYAU"
client_secret = "9JU2hmkHTD"

encText = urllib.parse.quote('오늘의집')
url = "https://openapi.naver.com/v1/search/blog?query=" + encText + "&display=100"  # json 결과
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
    de_list = []
    de_list_link = []
    for index, item in enumerate(response_body['items']):
        tmp_data = re.sub(r'[0-9|<|>|b|\/]+', '', item['description'])
        tmp_data_link = item['link']
        de_list.append(tmp_data)
        de_list_link.append(tmp_data_link)
else:
    print("Error Code:" + rescode)