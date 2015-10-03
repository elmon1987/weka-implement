# weka-implement

Current version: 1.21

This is the basic implement of Weka.

Features:
	- Fill missing value
	- Normalize using min-max and z-score formula
	- Discretize numerical value into nominal with equal-width and equal-frequency
	
Usage:
	- Load a file
	- If you want to see file's info, click Show Info
	- All result will be parsed as Weka's readable csv format and shown in the textbox below
	- Using filter as Discretize or Normalize need to select attribute used to filter
	- Input the number of bins in the textbox next to Equal-width button if you want to discretize by equal-width
	- Input the weight of each bin in the textbox next to Equal-frequency button if you want to discretize by equal-frequency
	- Debug and Terminate mode is for developers to see working data easier
	- Can load and save as .csv format
	
Bonus
	- Pre-packed with 2 dataset of wine
	