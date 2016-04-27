#Sample
A small sample project which illustrates the differences between synchronous, asynchronous,
and concurrent programming. Also highlights the fact that asynchronous code is not necessarily
concurrent, and that concurrent programming takes some additional effort.

Some points to keep in mind:
* If you're doing `await` inside of a loop, chances are you can parallelize the loop by extracting its body into a method/lambda and using `Select`
* To coordinate a fixed number of tasks (like when looking up a `Company`'s two `Office`s), create the tasks upfront without `await`, then `await` them later in whatever order you need
* To coordinate an arbitrary number of tasks (like when looking up all `Employee`s within an `Office`), use `Task.WhenAll` to orchestrate it
* This code does not do granular error handling, particularly around `Task.WhenAll` (if any task in the list fails, the overall task fails -- samples coming soon!