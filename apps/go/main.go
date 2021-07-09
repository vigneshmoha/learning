package main

import (
	"fmt"
	utils "learning/apps/go/utils"
	// web "learning/apps/go/web"
)

func main() {
	// Hello world 
	fmt.Println("Hello world")

	// Password Hashing
	// utils.TestPasswordGen("SimplePassword")

	// Simple http server
	// web.SimpleServer();

	// Factorial using recursion
	fmt.Println("Factorial of 7 is: ", utils.Factorial(7))
}
