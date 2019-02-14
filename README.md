# ConnectedPartyForm

This form was requested to collect data for employees who owned businesses, or had relatives who owned businesses that may be hired by the employer. It should also capture whether the employee or any of their relatives were auditors in the last three years.

The form updates a SQL database. In the DB three tables were created; 'Employee Info', 'Employee's COmpany Info', 'Relative's Info', and 'Auitor Info'

The following were the requirements (all fulfilled) :

1. The user should get an email when the form is submitted.

2. The employee should be able to submit info in each section several times, without having to fill out the entire form.

3. Due to the number of questions, a conditional radio button should be added. If that section applied to the employee, they would click the "Yes" radio button and the questions would appear.

4. If the employee fills out the form more than once, it should only update their existing record in 'Employee Info' table, and add rows to the other table as necessary.
