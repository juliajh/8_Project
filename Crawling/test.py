import requests
import json
import schedule
import time
import re

item_dict = {'CHAIR': '의자', 'SOFA': '소파', 'BED': '이불', 'REFRIGERATOR':'냉장고'}
color_dict = {'Yellow': '노란색', 'Blue': '파란색', 'Green':'초록색', 'White':'흰색', 'Red':'빨간색', 'Brown':'갈색'}

def item_info(item_name, color_type):
    client_id = 'bdpWYU7e70Thq9gFsYAU'
    client_secret = '9JU2hmkHTD'

    item_dict = {'CHAIR': '의자', 'SOFA': '소파', 'BED': '이불', 'REFRIGERATOR':'냉장고'}
    color_dict = {'Yellow': '노란색', 'Blue': '파란색', 'Green':'초록색', 'White':'흰색', 'Red':'빨간색', 'Brown':'갈색'}
    item_color = f"{item_dict[item_name]} {color_dict[color_type]}"
    name = item_name +'_'+ color_type

    naver_open_api = 'https://openapi.naver.com/v1/search/shop.json?query=' + item_color
    header_params = {"X-Naver-Client-Id":client_id, "X-Naver-Client-Secret":client_secret}
    res = requests.get(naver_open_api, headers=header_params)

    item_information = []
    if res.status_code == 200:

        data = res.json()
        print(data['items'])

        # for index, item in enumerate(data['items']):
        #     item_tmp = {}
        #     #item_tmp['Category'] = item_name
        #     #item_tmp['Color'] = color_type
        #     tmp = re.compile('[ㄱ-ㅎ]+').findall(item['title'])
        #     #item_tmp['Title'] = tmp
        #     #item_tmp['Link'] = item['link']
        #     #item_tmp['Image'] = item['image']
        #     #item_tmp['Price'] = item['lprice']
        #     #item_tmp['Brand'] = item['brand']
        #     #item_tmp['Price'] = item['lprice']
        #     #item_information.append(item_tmp)
        #     if index >= 3:
        #         break

    else:
        print ("Error Code:", res.status_code)

    #print(item_information)

item_info('BED', 'Red')