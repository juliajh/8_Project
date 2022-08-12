#import module
import numpy as np
import pandas as pd
import warnings
from sklearn.metrics.pairwise import cosine_similarity
warnings.filterwarnings('ignore')
from apyori import apriori
import matplotlib.pyplot as plt


# load data csv파일로 읽거나 바로 db로 접속해서 실시간으로 읽기
data = "" #데이터 저장 경로
df = pd.read_csv(data)


# 아이템 선택 후 배치 하면 다른 추천 아이템 배치
# 아이템 선택 하게 되면 같은 카테고리의 아이템은 데이터 프레임에서 지우기
df = df[['Category'] != '선택']



