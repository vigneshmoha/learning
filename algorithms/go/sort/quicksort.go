package sort

func QuickSort(array []int)[]int {
	if len(array) <= 1 {
		return array
	}

	q := partition(array)
	QuickSort(array[:q])
	QuickSort(array[q+1:])
	return array
}

func partition(array []int) int {
	lastindex := len(array) - 1
	lastelement := array[lastindex]
	index := -1

	for j:=0; j < lastindex; j++ {
		if array[j] <= lastelement {
			index++
			array[index], array[j] = array[j], array[index]
		}
	}

	array[index+1], array[lastindex] = array[lastindex], array[index+1]
	return index + 1
}
