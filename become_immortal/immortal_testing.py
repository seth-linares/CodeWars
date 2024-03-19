#%%
import numpy as np
import pandas as pd

class Immortal:
    Debug = False

    @staticmethod
    def elder_age(m, n, loss, time):
        count = 0
        row_sum = 0

        for i in range(min(m, n)):
            if i > 0:
                if Immortal.Debug:
                    print(f"row sum = {row_sum} at row i = {i - 1}, max number = {max(m, n)}")
                    print(f"row sum (binary) = {bin(row_sum)} at row i (binary) = {bin(i - 1)}, max number (binary) = {bin(max(m, n))}")
                    print(f"count = {count}, count (binary) = {bin(count)}")
                row_sum = 0

            for j in range(max(m, n)):
                if Immortal.Debug:
                    print(f"i: {i}, j: {j}")
                value = max((j ^ i) - loss, 0)
                count += value
                row_sum += value

                if j == max(m, n) - 1 and i == min(m, n) - 1:
                    if Immortal.Debug:
                        print(f"row sum = {row_sum} at row i = {i}, max number = {max(m, n)}")
                        print(f"row sum (binary) = {bin(row_sum)} at row i (binary) = {bin(i)}, max number (binary) = {bin(max(m, n))}")
                        print(f"count = {count}, count (binary) = {bin(count)}")

        return count if count < time else count % time

    @staticmethod
    def generate_xor_matrix(rows, cols, loss, export_to_pandas=False):
        matrix = np.zeros((rows, cols), dtype=int)
        for row in range(rows):
            for col in range(cols):
                matrix[row, col] = max((row ^ col) - loss, 0)

        if export_to_pandas:
            df = pd.DataFrame(matrix, index=[f"{r}" for r in range(rows)],
                                      columns=[f"{c}" for c in range(cols)])
            return df
        else:
            return matrix

    @staticmethod
    def print_matrix(rows, cols, loss, binary=False, use_pandas=False):
        if use_pandas:
            matrix = Immortal.generate_xor_matrix(rows, cols, loss, export_to_pandas=True)
            if binary:
                for col in matrix.columns:
                    matrix[col] = matrix[col].apply(lambda x: bin(x)[2:])
            return matrix
        else:
            matrix = Immortal.generate_xor_matrix(rows, cols, loss)
            max_width = max(len(bin(num)) for num in matrix.flatten())

            for row in range(rows):
                for col in range(cols):
                    value = bin(matrix[row, col])[2:] if binary else matrix[row, col]
                    print(f"{value:>{max_width}}", end=' ')
                    if col < cols - 1:
                        print("|", end=' ')
                print()

# Example usage
#%%
Immortal.print_matrix(9, 7, 0, binary=False, use_pandas=True)
#%%
Immortal.print_matrix(9, 7, 0, binary=True, use_pandas=True)
                

# %%
