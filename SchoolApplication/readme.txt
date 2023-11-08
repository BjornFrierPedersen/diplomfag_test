To create the database with docker-compose do the following:

0. Ensure that docker is running on your machine
1. Open you favorite cli
2. Navigate to the root directory of the solution
3. Run the command below:
   docker-compose -f docker-compose.yml up
4. Open a connection to the postgres server
5. Create the database with the name <SchoolDB>
6. Run the program and execute the --db-update command

If you already have a postgres server on your local machine just do step 4, 5 and 6