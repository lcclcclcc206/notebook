

## conda使用指南



### 安装

Anaconda：https://www.anaconda.com/products/individual#Downloads

Miniconda：https://repo.anaconda.com/miniconda/Miniconda3-latest-Linux-x86_64.sh

### 环境管理

```shell
conda create --name myenv python=3.9
conda activate myenv #激活环境
conda deactivate #退出环境

conda env list #列出所有环境

conda remove --name myenv --all #移除环境
conda env remove --name myenv
```



### 包管理

```shell
conda install requests

conda list #列出所有包

conda update requests
conda update all

conda list --export > a.txt #导出安装包的列表
conda install --file a.txt #根据文件安装包
```

